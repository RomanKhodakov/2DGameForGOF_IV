namespace ExampleGame
{
    public interface ILateExecute : IController
    {
        void LateExecute(float deltaTime);
    }
}