using System;

namespace ExampleGame
{
    public interface IUserInputProxy <T>
    {
        event Action<T> AxisOnChange;
        void GetAxis();
    }
}