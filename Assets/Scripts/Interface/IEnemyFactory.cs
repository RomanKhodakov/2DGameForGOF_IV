using System.Collections.Generic;

namespace ExampleGame
{
    internal interface IEnemyFactory
    {
        Enemy GetEnemy(string enemyName);
        Dictionary<string, IEnemyData> GetEnemiesDates();
    }
}