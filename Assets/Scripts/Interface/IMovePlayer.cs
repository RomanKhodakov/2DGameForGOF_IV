namespace ExampleGame
{
    public interface IMovePlayer
    {
        void Move(float deltaTime);
        void Cleanup();
    }
}