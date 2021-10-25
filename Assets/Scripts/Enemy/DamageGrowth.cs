namespace ExampleGame
{
    internal sealed class DamageGrowth : IEnemyAbility
    {
        private readonly float _base;
        public float Current { get; private set; }
        
        public DamageGrowth(float value)
        {
            _base = value;
            Current = _base;
        }

        public void ChangeCurrent(float damage)
        {
            Current = damage;
        }

        public void SetBase()
        {
            Current = _base;
        }
    }
}