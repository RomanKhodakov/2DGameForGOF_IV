using UnityEngine;

namespace ExampleGame
{
    internal abstract class State
    {
        protected Vector2 MoveDirection;

        public abstract void Handle(PlayerState playerState, float valueHorizontal, float valueVertical,
            Rigidbody2D playerRb, float playerSpeed, float deltaTime);
    }
}