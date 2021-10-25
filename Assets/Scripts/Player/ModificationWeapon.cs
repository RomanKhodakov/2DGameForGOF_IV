using System.Collections.Generic;

namespace ExampleGame
{
    public abstract class ModificationWeapon
    {
        protected abstract void AddModification(Bullet bullet, ShootType shootType);
        
        public void ApplyModification(Bullet bullet, ShootType shootType)
        {
            AddModification(bullet, shootType);
        }
    }
}