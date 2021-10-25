using System;
using UnityEngine;

namespace ExampleGame
{
    [Serializable]
    internal abstract class Enemy : MonoBehaviour, IMoveEnemy
    {
        public event Action<int, int, Health> OnTriggerEnterChange;
        private Health _enemyHealth;
        private DamageGrowth _damageGrowth;
        private SpeedGrowth _speedGrowth;

        public abstract void Move(Vector3 point, float speed);
        public abstract void SetEnemyAbility(IAbilityVisitor value, IEnemyAbilityExecutor executor);

        public IEnemyAbility this[AbilityType type]
        {
            get
            {
                return type switch
                {
                    AbilityType.DamageGrowth => _damageGrowth,
                    AbilityType.SpeedGrowth => _speedGrowth,
                    _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
                };
            }
            set
            {
                switch (type)
                {
                    case AbilityType.DamageGrowth:
                        _damageGrowth = (DamageGrowth)value;
                        break;
                    case AbilityType.SpeedGrowth:
                        _speedGrowth = (SpeedGrowth)value;
                        break;
                    default:
                        break;
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            OnTriggerEnterChange?.Invoke(other.gameObject.GetInstanceID(), gameObject.GetInstanceID(), _enemyHealth);
        }

        public void SetEnemyHealth(float max)
        {
            _enemyHealth = new Health(max);
        }
        public void SetEnemyBaseDamageGrowth(float value)
        {
            _damageGrowth = new DamageGrowth(value);
        }
        public void SetEnemyBaseSpeedGrowth(float value)
        {
            _speedGrowth = new SpeedGrowth(value);
        }
        
        public void RestoreEnemyHealth()
        {
            _enemyHealth.RestoreHp();
        }
    }
}