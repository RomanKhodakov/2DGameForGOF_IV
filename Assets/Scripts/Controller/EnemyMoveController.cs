using System.Collections.Generic;
using UnityEngine;

namespace ExampleGame
{
    public sealed class EnemyMoveController : IExecute
    {
        private readonly Dictionary<string, CompositeMoveEnemy> _movesEnemies;
        private readonly Transform _target;
        private readonly Dictionary<string, IEnemyData> _enemiesDates;

        public EnemyMoveController(Dictionary<string, CompositeMoveEnemy> movesEnemies, Transform target,
            Dictionary<string, IEnemyData> enemiesDates)
        {
            _enemiesDates = enemiesDates;
            _movesEnemies = movesEnemies;
            _target = target;
        }

        public void Execute(float deltaTime)
        {
            foreach (var enemyName in _movesEnemies.Keys)
            {
                _movesEnemies[enemyName].Move(_target.localPosition, _enemiesDates[enemyName].Speed * deltaTime);
            }
        }
    }
}