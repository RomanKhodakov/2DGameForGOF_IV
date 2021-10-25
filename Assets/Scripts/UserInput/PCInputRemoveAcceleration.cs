using System;
using UnityEngine;

namespace ExampleGame
{
    public sealed class PCInputRemoveAcceleration : IUserInputProxy <bool>
    {
        public event Action<bool> AxisOnChange = delegate(bool f) {  };
        
        public void GetAxis()
        {
            AxisOnChange.Invoke(Input.GetKeyUp(KeyCode.LeftShift));
        }
    }
}