using UnityEngine;

namespace ExampleGame
{
    public interface IPlayerFactory
    {
        GameObject CreatePlayer();
    }
}