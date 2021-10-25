using UnityEngine;

namespace ExampleGame
{
    public interface IUnit
    {

        Sprite Sprite { get; }
        string Name { get; }
        float Health { get; }
        float DamageModifier { get; }
        float Speed { get; }
        float AccelerationSpeed { get; }
        float Mass { get; }
        Vector2 Position { get; }
    }
}