namespace ExampleGame
{
    public sealed class Health
    {
        public float Max { get; }
        public float Current { get; private set; }
        
        public Health(float max)
        {
            Max = max;
            Current = Max;
        }

        public void ChangeCurrentHealth(float hp)
        {
            Current -= hp;
        }

        public void RestoreHp()
        {
            Current = Max;
        }
    }
}