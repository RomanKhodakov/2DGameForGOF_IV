using System.IO;
using UnityEngine;


namespace ExampleGame
{
    [CreateAssetMenu(fileName = "Data", menuName = "Data/Data")]
    public sealed class Data : ScriptableObject
    {
        [SerializeField] private string _playerDataPath;
        [SerializeField] private string _playerBulletDataPath;
        [SerializeField] private string _asteroidDataPath;
        [SerializeField] private string _squareAsteroidDataPath;
        private PlayerData _player;
        private PlayerBulletMissileData _playerBulletMissile;
        private AsteroidData _asteroidData;
        private SquareAsteroidData _squareAsteroidData;
        
        public PlayerData Player
        {
            get
            {
                if (_player == null)
                {
                    _player = Load<PlayerData>("Data/" + _playerDataPath);
                }

                return _player;
            }
        }
        public PlayerBulletMissileData PlayerBulletMissile
        {
            get
            {
                if (_playerBulletMissile == null)
                {
                    _playerBulletMissile = Load<PlayerBulletMissileData>("Data/" + _playerBulletDataPath);
                }

                return _playerBulletMissile;
            }
        }
        public AsteroidData AsteroidData
        {
            get
            {
                if (_asteroidData == null)
                {
                    _asteroidData = Load<AsteroidData>("Data/" + _asteroidDataPath);
                }

                return _asteroidData;
            }
        }
        public SquareAsteroidData SquareAsteroidData
        {
            get
            {
                if (_squareAsteroidData == null)
                {
                    _squareAsteroidData = Load<SquareAsteroidData>("Data/" + _squareAsteroidDataPath);
                }

                return _squareAsteroidData;
            }
        }

        private T Load<T>(string resourcesPath) where T : Object =>
            Resources.Load<T>(Path.ChangeExtension(resourcesPath, null));
    }
}