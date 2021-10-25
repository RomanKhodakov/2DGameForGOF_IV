using UnityEngine;

namespace ExampleGame
{
    internal class PlayerMoveVertical : State
    {
        public override void Handle(PlayerState playerState, float valueHorizontal, float valueVertical,
            Rigidbody2D playerRb, float playerSpeed, float deltaTime)
        {
            MoveDirection.Set(0, valueVertical);
            playerRb.AddForce(MoveDirection * playerSpeed * deltaTime);
            if (valueVertical == 0)
            {
                if (valueHorizontal == 0)
                {
                    playerState.State = new PlayerIdle();
                }
                else
                {
                    playerState.State = new PlayerMoveHorizontal();
                }
            }
            else if (valueHorizontal != 0)
            {
                playerState.State = new PlayerMoveDiagonal();
            }
        }
    }
}