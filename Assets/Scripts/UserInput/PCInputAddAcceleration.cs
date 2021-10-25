using System;
using UnityEngine;

namespace ExampleGame
{
    public sealed class PCInputAddAcceleration : IUserInputProxy <bool>
    {
        public event Action<bool> AxisOnChange = delegate(bool f) {  };
        
        public void GetAxis()
        {
            AxisOnChange.Invoke(Input.GetKeyDown(KeyCode.LeftShift));
        }
    }
}
