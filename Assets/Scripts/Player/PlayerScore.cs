using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ExampleGame
{
    internal sealed class PlayerScore
    {
        private float _current;
        
        public PlayerScore()
        {
            _current = 0;
        }

        public void ChangeCurrentScore(float value)
        {
            _current += value;
        }

        public string GetCurrentScore()
        {
            if (_current > 1000000) return $"Score: {Mathf.Round(_current / 1000000)} M";
            if (_current > 1000) return $"Score: {Mathf.Round(_current / 1000)} K";
            return $"Score: {_current}";
        }

        public void RestoreScore()
        {
            _current = 0;
        }
    }
}