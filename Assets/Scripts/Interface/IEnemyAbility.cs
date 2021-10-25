namespace ExampleGame
{
    public interface IEnemyAbility
    {
        public float Current { get; }
        public void ChangeCurrent(float damage);
        public void SetBase();
    }
}