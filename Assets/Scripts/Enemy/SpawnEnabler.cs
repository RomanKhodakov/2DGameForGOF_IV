namespace ExampleGame
{
    internal sealed class SpawnEnabler
    {
        private readonly float _rewindTime;
        private float _currentTime = 0;
        public bool SpawnAllowed = true;
        private readonly CompositeEnemyAbility _enemyAbility;

        public SpawnEnabler(float rewindTime, CompositeEnemyAbility enemyAbility)
        {
            _rewindTime = rewindTime;
            _enemyAbility = enemyAbility;
        }
        
        public void WaitForEndOfRewinding(float fixedDeltaTime)
        {
            _currentTime += fixedDeltaTime;
            if (_currentTime >= _rewindTime)
            {
                SpawnAllowed = true;
                _currentTime = 0;
                _enemyAbility.ResetEnemiesAbilities();
            }
        }
    }
}