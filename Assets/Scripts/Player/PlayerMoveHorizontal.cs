using UnityEngine;

namespace ExampleGame
{
    internal class PlayerMoveHorizontal : State
    {
        public override void Handle(PlayerState playerState, float valueHorizontal, float valueVertical,
            Rigidbody2D playerRb, float playerSpeed, float deltaTime)
        {
            MoveDirection.Set(valueHorizontal, 0);
            playerRb.AddForce(MoveDirection * playerSpeed * deltaTime);
            if (valueHorizontal == 0)
            {
                if (valueVertical == 0)
                {
                    playerState.State = new PlayerIdle();
                }
                else
                {
                    playerState.State = new PlayerMoveVertical();
                }
            }
            else if (valueVertical != 0)
            {
                playerState.State = new PlayerMoveDiagonal();
            }
        }
    }
}