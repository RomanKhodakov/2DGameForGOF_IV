using UnityEngine;

namespace ExampleGame
{
    public interface IBulletData
    {
        float Speed { get; }
        float Mass { get; }
        float Damage { get; }
        string Name { get; }
        
        float Offset { get; }
        float LifeTime { get; }
        int BaseBulletPullCount { get; }
    }
}
