namespace ExampleGame
{
    public interface IPlayerAttack
    {
        void Attack(float deltaTime);
        void Cleanup();
    }
}