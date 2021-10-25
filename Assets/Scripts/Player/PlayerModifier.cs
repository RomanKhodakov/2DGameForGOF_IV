namespace ExampleGame
{
    internal class PlayerModifier
    {
        protected readonly PlayerInitialization Player;
        private PlayerModifier _next;
    
        public PlayerModifier(PlayerInitialization player)
        {
            Player = player;
        }

        public void Add(PlayerModifier cm)
        {
            if (_next != null)
            {
                _next.Add(cm);
            }
            else
            {
                _next = cm;
            }
        }

        public virtual void Handle() => _next?.Handle();
    }

}