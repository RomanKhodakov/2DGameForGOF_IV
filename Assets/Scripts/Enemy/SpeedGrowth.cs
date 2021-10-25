namespace ExampleGame
{
    internal sealed class SpeedGrowth : IEnemyAbility
    {
        private readonly float _base;
        public float Current { get; private set; }
        
        public SpeedGrowth(float value)
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