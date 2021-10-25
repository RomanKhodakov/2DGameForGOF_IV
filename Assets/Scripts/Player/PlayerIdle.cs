using UnityEngine;

namespace ExampleGame
{
    internal class PlayerIdle : State
    {
        public override void Handle(PlayerState playerState, float valueHorizontal, float valueVertical,
            Rigidbody2D playerRb, float playerSpeed, float deltaTime)
        {
            if (valueHorizontal != 0)
            {
                if (valueVertical != 0)
                {
                    playerState.State = new PlayerMoveDiagonal();
                }
                else
                {
                    playerState.State = new PlayerMoveHorizontal();
                }
            }
            else if (valueVertical != 0)
            {
                playerState.State = new PlayerMoveVertical();
            }
        }
    }
}