using UnityEngine;

namespace ExampleGame
{
    public interface IMoveEnemy
    {
        void Move(Vector3 point, float speed);
    }
}