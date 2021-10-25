namespace ExampleGame
{
    internal interface IEnemyAbilityExecutor
    {
        public SpeedGrowth GetCurrentSpeedGrowth();
        public DamageGrowth GetCurrentDamageGrowth();
        public void FixedExecute(float fixedDeltaTime);
        public void ResetEnemyAbilities();
    }
}
