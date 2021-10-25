namespace ExampleGame
{
    internal class EnemyAbilityExecutor : IEnemyAbilityExecutor
    {
        private readonly SpeedGrowth _speedGrowth;
        private readonly DamageGrowth _damageGrowth;
        private float _tempTime = 1;

        public EnemyAbilityExecutor(float baseValue)
        {
            _speedGrowth = new SpeedGrowth(baseValue);
            _damageGrowth = new DamageGrowth(baseValue);
        }

        public void FixedExecute(float fixedDeltaTime)
        {
            _tempTime += fixedDeltaTime / 5;
            _speedGrowth.ChangeCurrent(_tempTime);
            _damageGrowth.ChangeCurrent(_tempTime);
        }

        public void ResetEnemyAbilities()
        {
            _damageGrowth.SetBase();
            _speedGrowth.SetBase();
            _tempTime = 1;
        }

        public SpeedGrowth GetCurrentSpeedGrowth() => _speedGrowth;
        public DamageGrowth GetCurrentDamageGrowth() => _damageGrowth;
    }
}