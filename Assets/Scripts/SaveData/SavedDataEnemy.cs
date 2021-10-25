using System;

namespace ExampleGame
{
    [Serializable]
    internal sealed class SavedDataEnemy
    {
        public UnitData unit;
        public override string ToString() => $"your enemy: {unit}";
    }

    [Serializable]
    public struct UnitData
    {
        public string type;
        public float health;

        private UnitData(string enemyType, float enemyHealth)
        {
            type = enemyType;
            health = enemyHealth;
        }

        public override string ToString() => $" type = {type}, health = {health}";
    }
}