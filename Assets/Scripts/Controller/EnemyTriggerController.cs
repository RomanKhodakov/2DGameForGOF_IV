using System.Collections.Generic;
using UnityEngine;

namespace ExampleGame
{
    internal sealed class EnemyTriggerController : IInitialization, ICleanup
    {
        private readonly int _playerID;
        private readonly PlayerScore _playerScore;
        private readonly PlayerInitialization _player;
        private readonly EnemyInitialization _enemiesInitialization;
        private readonly Dictionary<int, Enemy> _enemiesWithID;
        private readonly Dictionary<int, Bullet> _bulletsWithID;
        private readonly ViewServices<Bullet> _bulletViewServices;
        private readonly CompositeTimeBody _enemiesTimeBodies;
        private const float HpLoss = 20; 
        private const float Score = 2123.32f;

        public EnemyTriggerController(EnemyInitialization enemiesInitialization, PlayerInitialization player,
            IBulletFactory bulletFactory)
        {
            _player = player;
            _enemiesInitialization = enemiesInitialization;
            _playerScore = player.GetPlayerScore();
            _playerID = player.GetPlayerTransform().gameObject.GetInstanceID();
            _enemiesWithID = enemiesInitialization.GetEnemiesWithID();
            _enemiesTimeBodies = enemiesInitialization.GetEnemiesTimeBodies();
            _bulletsWithID = bulletFactory.GetBulletsWithID();
            _bulletViewServices = bulletFactory.GetBulletViewServices();
        }

        public void Initialization()
        {
            foreach (var enemy in _enemiesWithID.Values)
            {
                enemy.OnTriggerEnterChange += EnemyOnOnTriggerEnterChange;
            }
        }

        private void EnemyOnOnTriggerEnterChange(int otherID, int enemyID, Health enemyHealth)
        {
            if (otherID == _playerID)
            {
                _player.GetPlayerModifier(
                    Mathf.Round(HpLoss * _enemiesWithID[enemyID][AbilityType.DamageGrowth].Current)).Handle();
                _enemiesInitialization.ReturnEnemyToPool(enemyID);
                if (_player.GetPlayerHp().Current <= 0)
                {
                    _enemiesTimeBodies.StartRewind();
                    _enemiesInitialization.GetSpawnEnabler().SpawnAllowed = false;
                    _player.GetPlayerHp().RestoreHp();
                    _player.GetPlayerDamageModifier().SetBaseDamageModifier();
                    _player.GetPlayerScore().RestoreScore();
                }
            }

            if (_bulletsWithID.ContainsKey(otherID))
            {
                _bulletViewServices.Destroy(_bulletsWithID[otherID]);
                enemyHealth.ChangeCurrentHealth(_bulletsWithID[otherID].Damage *
                                                _player.GetPlayerDamageModifier().Current);
                if (enemyHealth.Current <= 0)
                {
                    _enemiesInitialization.ReturnEnemyToPool(enemyID);
                    _playerScore.ChangeCurrentScore(Score);
                }
            }
        }

        public void Cleanup()
        {
            foreach (var enemy in _enemiesWithID.Values)
            {
                enemy.OnTriggerEnterChange += EnemyOnOnTriggerEnterChange;
            }
        }
    }
}