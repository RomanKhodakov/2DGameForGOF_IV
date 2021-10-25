namespace ExampleGame
{
    internal sealed class PlayerBridge : IExecute, ICleanup
    {
        private readonly IMovePlayer _movePlayer;
        private readonly IPlayerAttack _playerAttack;

        public PlayerBridge(IMovePlayer movePlayer, IPlayerAttack playerAttack)
        {
            _movePlayer = movePlayer;
            _playerAttack = playerAttack;
        }

        public void Execute(float deltaTime)
        {
            _movePlayer.Move(deltaTime);
            _playerAttack.Attack(deltaTime);
        }

        public void Cleanup()
        {
            _movePlayer.Cleanup();
            _playerAttack.Cleanup();
        }
    }
}