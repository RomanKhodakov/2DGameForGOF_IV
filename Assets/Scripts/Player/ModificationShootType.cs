using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ExampleGame
{
    internal sealed class ModificationShootType : ModificationWeapon
    {
        private readonly Transform _unit;
        private readonly IBulletData _bulletData;

        public ModificationShootType(Transform unit, IBulletData bulletData)
        {
            _unit = unit;
            _bulletData = bulletData;
        }
        protected override void AddModification(Bullet bullet, ShootType shootType)
        {
            bullet.transform.position = _unit.position + _unit.up * _bulletData.Offset;
            bullet.transform.rotation = _unit.rotation * Quaternion.Euler(0, 0, -90f);
            switch (shootType)
            {
                case ShootType.Standard:
                    bullet.gameObject.GetOrAddComponent<Rigidbody2D>().AddForce(_unit.up * _bulletData.Speed);
                    bullet.SetDamage(_bulletData.Damage * 2);
                    break;
                case ShootType.Faster:
                    bullet.gameObject.GetOrAddComponent<Rigidbody2D>().AddForce(_unit.up * (_bulletData.Speed * 2));
                    bullet.SetDamage(_bulletData.Damage);
                    break;
                default:
                    break;
            }
        }
    }
}
