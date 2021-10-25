using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ExampleGame
{
    public interface ISaveDataRepository <T>
    {
        public List<T> Load();
    }
}
