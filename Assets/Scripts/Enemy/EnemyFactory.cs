using System.Collections.Generic;
using UnityEngine;

namespace ExampleGame
{
    internal sealed class EnemyFactory : IEnemyFactory
    {
        private readonly Dictionary<string, IEnemyData> _enemiesDates;

        public EnemyFactory(IEnemyParser enemyParser)
        {
            _enemiesDates = enemyParser.GetEnemies();
        }

        public Enemy GetEnemy(string enemyName)
        {
            var enemyData = _enemiesDates[enemyName];
            var res = Resources.Load<Enemy>($"Enemy/{enemyData.Name}");
            res.gameObject.SetName(enemyName).AddRigidbody2D(enemyData.Mass)
                .GetOrAddColliderType2D(enemyData.TypeOfEnemy).isTrigger = true;
            return res;
        }

        public Dictionary<string, IEnemyData> GetEnemiesDates()
        {
            return _enemiesDates;
        }
    }
}