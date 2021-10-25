using UnityEngine;

namespace ExampleGame
{
    public sealed class PlayerFactory : IPlayerFactory
    {
        private readonly IUnit _playerData;

        public PlayerFactory(IUnit playerData)
        {
            _playerData = playerData;
        }

        public GameObject CreatePlayer()
        {
            return new GameObject(_playerData.Name).AddSprite(_playerData.Sprite).AddCircleCollider2D()
                .AddRigidbody2D(_playerData.Mass);
        }
    }
}