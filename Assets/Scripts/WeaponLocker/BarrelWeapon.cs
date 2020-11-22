using UnityEngine;

namespace Asteroids.WeaponLocker
{
    public class BarrelWeapon : IWeapon
    {
        private BulletFactory _bulletFactory;
        private Transform _barrel;
        private readonly float _force;

        public BarrelWeapon(Transform barrel, Rigidbody2D bullet, float force)
        {
            _barrel = barrel;
            _force = force;
            _bulletFactory = new BulletFactory(bullet);
        }

        public void Fire()
        {
            var bullet = _bulletFactory.GetBullet(_barrel.position, _barrel.rotation);
            bullet.AddForce(_barrel.up * _force);
        }
    }
}