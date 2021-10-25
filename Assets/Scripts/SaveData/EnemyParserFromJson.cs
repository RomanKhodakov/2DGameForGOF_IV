using System.Collections.Generic;

namespace ExampleGame
{
    internal sealed class EnemyParserFromJson : IEnemyParser
    {
        private readonly List<SavedDataEnemy> _enemies;
        private readonly Data _data;
        private readonly Dictionary<string, IEnemyData> _enemiesDates;
        // Поступает 2 одинаковых типа врагов с разным хп, поэтому в качестве ключа будет использован тип + хп 

        public EnemyParserFromJson(ISaveDataRepository<SavedDataEnemy> saveDataRepository, Data data)
        {
            _enemiesDates = new Dictionary<string, IEnemyData>();
            _enemies = saveDataRepository.Load();
            _data = data;
        }

        public Dictionary<string, IEnemyData> GetEnemies()
        {
            foreach (var enemy in _enemies)
            {
                switch (enemy.unit.type)
                {
                    case "mag":
                        if (!_enemiesDates.ContainsKey($"{_data.AsteroidData.Name}|{enemy.unit.health}"))
                        {
                            _enemiesDates.Add($"{_data.AsteroidData.Name}|{enemy.unit.health}", _data.AsteroidData);
                        }

                        break;
                    case "infantry":
                        if (!_enemiesDates.ContainsKey($"{_data.SquareAsteroidData.Name}|{enemy.unit.health}"))
                        {
                            _enemiesDates.Add($"{_data.SquareAsteroidData.Name}|{enemy.unit.health}",
                                _data.SquareAsteroidData);
                        }

                        break;
                    default:
                        break;
                }
            }

            return _enemiesDates;
        }
    }
}