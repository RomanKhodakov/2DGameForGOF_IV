using UnityEngine;

namespace ExampleGame
{
    internal sealed class Asteroid : Enemy
    {
        public override void Move(Vector3 point, float speed)
        {
            var dir = (point - transform.localPosition).normalized;
            gameObject.GetOrAddComponent<Rigidbody2D>().velocity = dir * (speed * this[AbilityType.SpeedGrowth].Current);
        }

        public override void SetEnemyAbility(IAbilityVisitor value, IEnemyAbilityExecutor executor)
        {
            value.Visit(this, executor);
        }
    }
}