using System;
using UnityEngine;

namespace ExampleGame
{
    public sealed class PCInputVertical : IUserInputProxy <float> 
    {
        public event Action<float> AxisOnChange = delegate(float f) {  };
        
        public void GetAxis()
        {
            AxisOnChange.Invoke(Input.GetAxis(AxisManager.VERTICAL));
        }
    }
}