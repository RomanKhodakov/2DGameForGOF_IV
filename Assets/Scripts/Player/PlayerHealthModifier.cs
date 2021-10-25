namespace ExampleGame
{
    internal sealed class PlayerHealthModifier : PlayerModifier
    {
        private readonly Health _health;
        private readonly float _hpLoss;

        public PlayerHealthModifier(PlayerInitialization player, float hpLoss) : base(player)
        {
            _health = Player.GetPlayerHp();
            _hpLoss = hpLoss;
        }

        public override void Handle()
        { 
            _health.ChangeCurrentHealth(_hpLoss);
            base.Handle();
        }
    }

}