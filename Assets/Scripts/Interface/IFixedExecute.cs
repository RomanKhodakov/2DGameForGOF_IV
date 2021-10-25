namespace ExampleGame
{
    public interface IFixedExecute : IController
    {
        void FixedExecute(float deltaTime);
    }
}