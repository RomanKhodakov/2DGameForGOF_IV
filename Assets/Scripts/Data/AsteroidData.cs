using UnityEngine;

namespace ExampleGame
{
    [CreateAssetMenu(fileName = "AsteroidSettings", menuName = "Data/Enemy/AsteroidSettings")]
    public sealed class AsteroidData : ScriptableObject, IEnemyData
    {
        [SerializeField] private string _name;
        [SerializeField, Range(0.01f, 3000)] private float _speed;
        [SerializeField, Range(0.01f, 10)] private float _mass;
        [SerializeField, Range(1, 30)] private int _basePullCount;
        [SerializeField, Range(10, 100)] private float _spawnRange;
        [SerializeField, Range(0.5f, 10)] private float _spawnTime;
        public EnemyType TypeOfEnemy => EnemyType.Round;
        public int BasePullCount => _basePullCount;
        public float Speed => _speed;
        public float Mass => _mass;
        public float SpawnRange => _spawnRange;
        public float SpawnTime => _spawnTime;
        public string Name => _name;
    }
}