namespace ExampleGame
{
    internal sealed class PlayerDamageModifier : PlayerModifier
    {
        private readonly DamageModifier _damageModifier;
        private readonly Health _playerHealth;

        public PlayerDamageModifier(PlayerInitialization player) : base(player)
        {
            _playerHealth = Player.GetPlayerHp();
            _damageModifier = Player.GetPlayerDamageModifier();
        }


        public override void Handle()
        {
            if (_playerHealth.Current >= _playerHealth.Max / 2)
            {
                _damageModifier.ChangeDamageModifier(1);
            }
            else if (_playerHealth.Current >= _playerHealth.Max / 4)
            {
                _damageModifier.ChangeDamageModifier(2);
            }
            else _damageModifier.ChangeDamageModifier(3);
            base.Handle();
        }
    }

}