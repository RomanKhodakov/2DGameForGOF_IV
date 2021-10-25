namespace ExampleGame
{
    internal interface IAbilityVisitor
    {
        void Visit(Asteroid enemy, IEnemyAbilityExecutor info);
        void Visit(SquareAsteroid enemy, IEnemyAbilityExecutor info);
    }
}