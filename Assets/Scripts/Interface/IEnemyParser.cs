using System.Collections.Generic;

namespace ExampleGame
{
    public interface IEnemyParser
    {
        public Dictionary<string, IEnemyData> GetEnemies();
    }
}
