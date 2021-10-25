using System.Collections.Generic;

namespace ExampleGame
{
    public interface IBulletFactory
    {
        Bullet GetBullet();
        public IBulletData GetBulletData();
        public ViewServices<Bullet> GetBulletViewServices();
        public Dictionary<int, Bullet> GetBulletsWithID();
    }
}