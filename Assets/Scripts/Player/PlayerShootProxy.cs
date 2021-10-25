using UnityEngine;

namespace ExampleGame
{
    public sealed class PlayerShootProxy : IPlayerAttack
    { // класс для проверки перед стрельбой, можно ли стрелять (Proxy)
        private readonly IPlayerAttack _shootController;
        private readonly UnlockWeapon _unlockWeapon;

        public PlayerShootProxy(IPlayerAttack shootController, UnlockWeapon unlockWeapon)
        {
            _shootController = shootController;
            _unlockWeapon = unlockWeapon;
        }

        public void Attack(float deltaTime)
        {
            if (_unlockWeapon.IsUnlock)
            {
                _shootController.Attack(deltaTime);
            }
            else
            {
                Debug.Log("Weapon is lock");
            }
        }

        public void Cleanup()
        {
            _shootController.Cleanup();
        }
    }
}


