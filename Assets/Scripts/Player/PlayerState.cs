using UnityEngine;

namespace ExampleGame
{
    internal sealed class PlayerState
    {
        private State _state;
        private readonly Rigidbody2D _playerRb;

        public PlayerState(State state, Rigidbody2D playerRb)
        {
            State = state;
            _playerRb = playerRb;
        }

        public State State
        {
            get => _state;
            set => _state = value;
        }

        public void Request(float valueHorizontal, float valueVertical, float playerSpeed,
            float deltaTime)
        {
            _state.Handle(this, valueHorizontal, valueVertical, _playerRb, playerSpeed, deltaTime);
        }
    }
}