using UnityEngine;

namespace ExampleGame
{
    public interface IEnemyData
    {
        EnemyType TypeOfEnemy { get; }
        public int BasePullCount { get; }
        float SpawnRange { get; }
        float SpawnTime { get; }
        float Speed { get; }
        float Mass { get; }
        string Name { get; }
    }
}