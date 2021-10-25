using UnityEngine;

namespace ExampleGame
{
    internal sealed class PlayerInitialization : IInitialization
    {
        private readonly GameObject _player;
        private readonly Health _playerHealth;
        private readonly DamageModifier _playerDamageModifier;
        private readonly PlayerScore _playerScore;
        private readonly PlayerState _playerState;

        public PlayerInitialization(IPlayerFactory playerFactory, IUnit player)
        {
            _player = playerFactory.CreatePlayer();
            _player.transform.position = player.Position;
            _playerHealth = new Health(player.Health);
            _playerDamageModifier = new DamageModifier(player.DamageModifier);
            _playerScore = new PlayerScore();
            _playerState = new PlayerState(new PlayerIdle(), _player.GetOrAddComponent<Rigidbody2D>());
        }
        
        public void Initialization()
        {
        }

        public Transform GetPlayerTransform() => _player.transform;

        public Rigidbody2D GetPlayerRigidbody() => _player.GetOrAddComponent<Rigidbody2D>();

        public Health GetPlayerHp() => _playerHealth;

        public DamageModifier GetPlayerDamageModifier() => _playerDamageModifier;

        public PlayerScore GetPlayerScore() => _playerScore;
        public PlayerState GetPlayerState() => _playerState;

        public PlayerModifier GetPlayerModifier(float hpLoss)
        {
            PlayerModifier playerModifier = new PlayerModifier(this);
            playerModifier.Add(new PlayerHealthModifier(this, hpLoss));
            playerModifier.Add(new PlayerDamageModifier(this));
            return playerModifier;
        }
    }
}