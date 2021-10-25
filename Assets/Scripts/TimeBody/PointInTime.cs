using UnityEngine;


namespace ExampleGame
{
    internal sealed class PointInTime
    {
        public Vector3 Position;
        public Quaternion Rotation;
        public Vector3 Velocity;
        public readonly float AngularVelocity;
        public readonly bool IsActive;

        public PointInTime (Vector3 position, Quaternion rotation, Vector3 velocity, float angularVelocity, bool isActive)
        {
            Position = position;
            Rotation = rotation;
            Velocity = velocity;
            AngularVelocity = angularVelocity;
            IsActive = isActive;
        }
    }
}