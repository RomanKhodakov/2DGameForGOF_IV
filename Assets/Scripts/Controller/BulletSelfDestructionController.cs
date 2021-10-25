using System.Collections.Generic;
using UnityEngine;

namespace ExampleGame
{
    public sealed class BulletSelfDestructionController : IExecute
    {
        private readonly ViewServices<Bullet> _viewServices;
        private readonly float _lifeTime;
        private readonly Dictionary<int, Bullet> _bulletsWithID;

        public BulletSelfDestructionController(IBulletFactory bulletFactory)
        {
            _lifeTime = bulletFactory.GetBulletData().LifeTime;
            _viewServices = bulletFactory.GetBulletViewServices();
            _bulletsWithID = bulletFactory.GetBulletsWithID();
        }

        public void Execute(float deltaTime)
        {
            foreach (var bullet in _bulletsWithID.Values)
            {
                bullet.SelfDestruction(_viewServices, deltaTime, _lifeTime);
            }
        }
    }
}