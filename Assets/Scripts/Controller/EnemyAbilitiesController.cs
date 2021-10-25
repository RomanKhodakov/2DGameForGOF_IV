using System.Collections.Generic;
using UnityEngine;

namespace ExampleGame
{
    internal sealed class EnemyAbilitiesController : IFixedExecute
    {
        private readonly CompositeEnemyAbility _enemyAbility;

        public EnemyAbilitiesController(CompositeEnemyAbility enemyAbility)
        {
            _enemyAbility = enemyAbility;
        }

        public void FixedExecute(float fixedDeltaTime)
        {
            _enemyAbility.FixedExecute(fixedDeltaTime);
        }
    }
}