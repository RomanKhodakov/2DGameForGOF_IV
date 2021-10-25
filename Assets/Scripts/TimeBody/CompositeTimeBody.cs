using System.Collections.Generic;

namespace ExampleGame
{
    internal sealed class CompositeTimeBody: IFixedExecute
    {
        private readonly List<TimeBody> _timeBodies = new List<TimeBody>();

        public void AddUnit(TimeBody unit)
        {
            _timeBodies.Add(unit);
        }

        public void RemoveUnit(TimeBody unit)
        {
            _timeBodies.Remove(unit);
        }

        public void StartRewind()
        {
            for (var i = 0; i < _timeBodies.Count; i++)
            {
                _timeBodies[i].StartRewind(); 
            }
        }

        public void FixedExecute(float fixedDeltaTime)
        {
            for (int i = 0; i < _timeBodies.Count; i++)
            {
                _timeBodies[i].FixedExecute(); 
            }
        }
    }
}