using System;
using UnityEngine;

namespace ExampleGame
{
    public sealed class PCInputMousePosition : IUserInputProxy <Vector3>
    {
        public event Action<Vector3> AxisOnChange = delegate(Vector3 f) {  };
        
        public void GetAxis()
        {
            AxisOnChange.Invoke(Input.mousePosition);
        }
    }
}
