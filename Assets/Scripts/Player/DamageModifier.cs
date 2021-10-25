namespace ExampleGame
{
    internal sealed class DamageModifier
    {
        private float BaseDamage { get; }
        public float Current { get; private set; }
        
        public DamageModifier(float baseDamage)
        {
            BaseDamage = baseDamage;
            Current = BaseDamage;
        }

        public void ChangeDamageModifier(float newDamage)
        {
            Current = newDamage;
        }

        public void SetBaseDamageModifier()
        {
            Current = BaseDamage;
        }
    }
}