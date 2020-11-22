using UnityEngine;

namespace Asteroids.WeaponLocker
{
    public class BulletFactory
    {
        private readonly Rigidbody2D _bullet;

        public BulletFactory(Rigidbody2D bullet)
        {
            _bullet = bullet;
        }

        public Rigidbody2D GetBullet(Vector3 position, Quaternion rotation)
            => Object.Instantiate(_bullet, position, rotation);
    }
}