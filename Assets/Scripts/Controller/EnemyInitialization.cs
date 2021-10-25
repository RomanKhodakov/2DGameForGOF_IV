using System.Collections.Generic;

namespace ExampleGame
{
    internal sealed class EnemyInitialization : IInitialization
    {
        public const float RecordTime = 3f;
        private const float BaseGrowthParams = 1f;
        private readonly Dictionary<string, CompositeMoveEnemy> _enemiesMoves;
        private readonly Dictionary<string, Stack<Enemy>> _enemiesPools;
        private readonly Dictionary<int, Enemy> _enemiesWithID;
        private readonly ViewServices<Enemy> _viewServices;
        private readonly CompositeTimeBody _timeBodies;
        private readonly SpawnEnabler _spawnEnabler;
        private readonly IAbilityVisitor _enemyAbilityVisitor;
        private readonly CompositeEnemyAbility _enemyAbilities;

        public EnemyInitialization(IEnemyFactory enemyFactory)
        {
            _enemiesMoves = new Dictionary<string, CompositeMoveEnemy>();
            _enemiesPools = new Dictionary<string, Stack<Enemy>>();
            _enemiesWithID = new Dictionary<int, Enemy>();
            _viewServices = new ViewServices<Enemy>();
            _timeBodies = new CompositeTimeBody();
            _enemyAbilities = new CompositeEnemyAbility();
            _spawnEnabler = new SpawnEnabler(RecordTime, _enemyAbilities);
            _enemyAbilityVisitor = new EnemyAbilityVisitor();
            foreach (var enemyDataName in enemyFactory.GetEnemiesDates().Keys)
            {
                _enemiesMoves.Add(enemyDataName, new CompositeMoveEnemy());
                _enemiesPools.Add(enemyDataName, new Stack<Enemy>());
                string [] enemyParams = enemyDataName.Split('|');
                for (int i = 0; i < enemyFactory.GetEnemiesDates()[enemyDataName].BasePullCount; i++)
                {
                    var instance = _viewServices.Instantiate(enemyFactory.GetEnemy(enemyDataName));
                    instance.SetEnemyHealth(int.Parse(enemyParams[1]));
                    instance.SetEnemyBaseDamageGrowth(BaseGrowthParams);
                    instance.SetEnemyBaseSpeedGrowth(BaseGrowthParams);
                    _timeBodies.AddUnit(new TimeBody(instance, this));
                    _enemiesPools[enemyDataName].Push(instance);
                }
            }
        }

        public void Initialization()
        {
            foreach (var enemiesPoll in _enemiesPools)
            {
                foreach (var enemy in enemiesPoll.Value)
                {
                    _enemiesWithID.Add(enemy.gameObject.GetInstanceID(), enemy);
                    _viewServices.Destroy(enemy);
                }
            }
        }

        public Dictionary<string, CompositeMoveEnemy> GetMovesEnemies() => _enemiesMoves;

        public Dictionary<string, Stack<Enemy>> GetEnemiesStacks() =>_enemiesPools;
        public Dictionary<int, Enemy> GetEnemiesWithID() => _enemiesWithID;

        public ViewServices<Enemy> GetEnemiesViewService() => _viewServices;
        public CompositeTimeBody GetEnemiesTimeBodies() => _timeBodies;

        public SpawnEnabler GetSpawnEnabler() => _spawnEnabler;

        public IAbilityVisitor GetEnemyAbility() => _enemyAbilityVisitor;
        public CompositeEnemyAbility GetEnemyAbilities() => _enemyAbilities;

        public IEnemyAbilityExecutor GetAbilityExecutor()
        {
            var enemyAbilityExecutor = new EnemyAbilityExecutor(BaseGrowthParams);
            _enemyAbilities.AddUnit(enemyAbilityExecutor);
            return enemyAbilityExecutor;
        }
        public void ReturnEnemyToPool(int enemyID)
        {
            _enemiesPools[_enemiesWithID[enemyID].gameObject.name].Push(_enemiesWithID[enemyID]);
            _enemiesMoves[_enemiesWithID[enemyID].gameObject.name].RemoveUnit(_enemiesWithID[enemyID]);
            _enemiesWithID[enemyID].RestoreEnemyHealth();
            _viewServices.Destroy(_enemiesWithID[enemyID]);
        }
    }
}