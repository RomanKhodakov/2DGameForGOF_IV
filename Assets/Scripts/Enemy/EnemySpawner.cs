using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ExampleGame
{
    internal sealed class EnemySpawner : IEnemySpawner
    {
        private float _randomAngle;
        private Vector3 _spawnRange;
        private readonly Transform _playerTransform;
        private Dictionary<string, float> _enemyCurrentTime;
        private readonly ViewServices<Enemy> _viewServices;
        private readonly Dictionary<string, IEnemyData> _enemiesDates;
        private readonly Dictionary<string, Stack<Enemy>> _enemiesPools;
        private readonly Dictionary<string, CompositeMoveEnemy> _listEnemiesMoves;
        private readonly EnemyInitialization _enemyInitialization;

        public EnemySpawner(EnemyInitialization enemyInitialization ,IEnemyFactory enemiesFactory, Transform playerTransform)
        {
            _enemyInitialization = enemyInitialization;
            _viewServices = enemyInitialization.GetEnemiesViewService();
            _enemiesPools = enemyInitialization.GetEnemiesStacks();
            _listEnemiesMoves = enemyInitialization.GetMovesEnemies();
            _enemiesDates = enemiesFactory.GetEnemiesDates();
            _playerTransform = playerTransform;
        }

        public void Initialization()
        {
            _enemyCurrentTime = new Dictionary<string, float>(_enemiesDates.Count);
            foreach (var enemyName in _enemiesPools.Keys)
            {
                _enemyCurrentTime.Add(enemyName,0f);
            }
        }


        public void SpawnEnemy(float fixedDeltaTime)
        {
            foreach (var enemyName in _enemiesPools.Keys)
            {
                _enemyCurrentTime[enemyName] += fixedDeltaTime;
                if (_enemiesPools[enemyName].Count > 0)
                {
                    if (_enemyCurrentTime[enemyName] > _enemiesDates[enemyName].SpawnTime)
                    {
                        GetFromPullEnemy(enemyName);
                        _enemyCurrentTime[enemyName] -= _enemiesDates[enemyName].SpawnTime;
                    }
                }
                else
                {
                    _enemyCurrentTime[enemyName] = 0;
                }
            }
        }

        private void GetFromPullEnemy(string enemyName)
        {
            _randomAngle = Random.Range(-Mathf.PI, Mathf.PI);
            _spawnRange.Set(_enemiesDates[enemyName].SpawnRange * Mathf.Cos(_randomAngle),
                _enemiesDates[enemyName].SpawnRange * Mathf.Sin(_randomAngle), 0);
            var instance = _viewServices.Instantiate(_enemiesPools[enemyName].Pop());
            _listEnemiesMoves[enemyName].AddUnit(instance);
            instance.SetEnemyAbility(_enemyInitialization.GetEnemyAbility(), _enemyInitialization.GetAbilityExecutor());
            instance.transform.position = _playerTransform.position + _spawnRange;
        }
    }
}