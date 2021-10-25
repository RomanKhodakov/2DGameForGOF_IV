using UnityEngine;


namespace ExampleGame
{
    internal sealed class EnemyAbilityVisitor : IAbilityVisitor
    {
        public void Visit(Asteroid enemy, IEnemyAbilityExecutor info)
        {
            enemy[AbilityType.SpeedGrowth] = info.GetCurrentSpeedGrowth();
        }

        public void Visit(SquareAsteroid enemy, IEnemyAbilityExecutor info)
        {
            enemy[AbilityType.DamageGrowth] = info.GetCurrentDamageGrowth();
        }

    }
}