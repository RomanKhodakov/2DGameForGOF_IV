using UnityEngine;

namespace ExampleGame
{
    internal sealed class PlayerShootController : IPlayerAttack
    {
        private readonly IUserInputProxy<bool> _mouseFire1Input;
        private readonly IUserInputProxy<bool> _mouseFire2Input;
        private readonly BulletInstantiator _bulletInstantiator;
        private bool _mouseFire1;
        private bool _mouseFire2;

        public PlayerShootController(
            (IUserInputProxy<Vector3> mousePosition, IUserInputProxy<bool> mouseFire1, IUserInputProxy<bool> mouseFire2)
                mouseInput, BulletInstantiator bulletInstantiator)
        {
            _bulletInstantiator = bulletInstantiator;
            _mouseFire1Input = mouseInput.mouseFire1;
            _mouseFire2Input = mouseInput.mouseFire2;
            _mouseFire1Input.AxisOnChange += Fire1OnAxisOnChange;
            _mouseFire2Input.AxisOnChange += Fire2OnAxisOnChange;
        }

        private void Fire1OnAxisOnChange(bool value)
        {
            _mouseFire1 = value;
        }

        private void Fire2OnAxisOnChange(bool value)
        {
            _mouseFire2 = value;
        }

        public void Attack(float deltaTime)
        {
            if (_mouseFire1)
            {
                _bulletInstantiator.LaunchBullet(ShootType.Standard);
            }

            if (_mouseFire2)
            {
                _bulletInstantiator.LaunchBullet(ShootType.Faster);
            }
        }

        public void Cleanup()
        {
            _mouseFire1Input.AxisOnChange -= Fire1OnAxisOnChange;
            _mouseFire2Input.AxisOnChange -= Fire2OnAxisOnChange;
        }
    }
}