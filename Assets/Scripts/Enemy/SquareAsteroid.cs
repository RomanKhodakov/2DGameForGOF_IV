using UnityEngine;

namespace ExampleGame
{
    internal sealed class SquareAsteroid : Enemy
    {

        public override void Move(Vector3 point, float speed)
        {
            var dir = (point - transform.localPosition).normalized;
            gameObject.GetOrAddComponent<Rigidbody2D>().velocity = dir * speed;
        }

        public override void SetEnemyAbility(IAbilityVisitor value, IEnemyAbilityExecutor executor)
        {
            value.Visit(this, executor);
        }
    }
}