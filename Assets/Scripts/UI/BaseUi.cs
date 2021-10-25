using UnityEngine;

namespace ExampleGame
{
    internal abstract class BaseUi
    {
        public abstract void SetActiveUi();  
        public abstract void ExecuteUi();  
        public abstract void Cancel();
    }
}