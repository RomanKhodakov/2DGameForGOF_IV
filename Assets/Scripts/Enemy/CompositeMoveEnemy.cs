using System.Collections.Generic;
using UnityEngine;

namespace ExampleGame
{
    public sealed class CompositeMoveEnemy : IMoveEnemy
    {
        private readonly List<IMoveEnemy> _moves = new List<IMoveEnemy>();

        public void AddUnit(IMoveEnemy unit)
        {
            _moves.Add(unit);
        }

        public void RemoveUnit(IMoveEnemy unit)
        {
            _moves.Remove(unit);
        }

        public void Move(Vector3 point, float speed)
        {
            for (var i = 0; i < _moves.Count; i++)
            {
                _moves[i].Move(point, speed); 
            }
        }
    }
}