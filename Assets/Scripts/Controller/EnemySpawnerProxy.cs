using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ExampleGame
{
    internal sealed class EnemySpawnerProxy : IFixedExecute, IInitialization
    {
        private readonly IEnemySpawner _enemySpawner;
        private readonly SpawnEnabler _spawnEnabler;

        public EnemySpawnerProxy(IEnemySpawner enemySpawner, SpawnEnabler spawnEnabler)
        {
            _enemySpawner = enemySpawner;
            _spawnEnabler = spawnEnabler;
        }

        public void FixedExecute(float fixedDeltaTime)
        {
            if (_spawnEnabler.SpawnAllowed)
            {
                _enemySpawner.SpawnEnemy(fixedDeltaTime);
            }
            else
            {
                _spawnEnabler.WaitForEndOfRewinding(fixedDeltaTime);
            }
        }

        public void Initialization()
        {
            _enemySpawner.Initialization();
        }
    }
}


