using System.Collections.Generic;

namespace ExampleGame
{
    internal sealed class BulletInstantiator
    { //класс для метода создания, применения модификаций к пуле и добавления её в словарь с ID и в ViewService
        private readonly IBulletFactory _bulletFactory;
        private readonly ModificationWeapon _modificationWeapon;
        private readonly ViewServices<Bullet> _viewServices;
        private readonly Dictionary<int, Bullet> _bulletPoolWithID;

        public BulletInstantiator(IBulletFactory bulletFactory, ModificationWeapon modificationWeapon,
            ViewServices<Bullet> viewServices)
        {
            _bulletFactory = bulletFactory;
            _modificationWeapon = modificationWeapon;
            _viewServices = viewServices;
            _bulletPoolWithID = bulletFactory.GetBulletsWithID();
        }

        public void LaunchBullet(ShootType shootType)
        {
            var bullet = _viewServices.Instantiate(_bulletFactory.GetBullet());
            if (!_bulletPoolWithID.ContainsKey(bullet.gameObject.GetInstanceID()))
            {
                _bulletPoolWithID.Add(bullet.gameObject.GetInstanceID(), bullet);
            }

            _modificationWeapon.ApplyModification(bullet, shootType);
        }
    }
}