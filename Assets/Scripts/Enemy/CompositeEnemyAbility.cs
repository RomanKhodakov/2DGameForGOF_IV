using System.Collections.Generic;
using UnityEngine;

namespace ExampleGame
{
    internal sealed class CompositeEnemyAbility
    {
        private readonly List<IEnemyAbilityExecutor> _executors = new List<IEnemyAbilityExecutor>();

        public void AddUnit(IEnemyAbilityExecutor unit)
        {
            _executors.Add(unit);
        }

        public void RemoveUnit(IEnemyAbilityExecutor unit)
        {
            _executors.Remove(unit);
        }

        public void FixedExecute(float fixedDeltaTime)
        {
            for (var i = 0; i < _executors.Count; i++)
            {
                _executors[i].FixedExecute(fixedDeltaTime); 
            }
        }

        public void ResetEnemiesAbilities()
        {
            for (var i = 0; i < _executors.Count; i++)
            {
                _executors[i].ResetEnemyAbilities(); 
            }
        }
    }
}