using UnityEngine;

namespace Asteroids.WeaponLocker
{
    public class ReloadingWeapon : IWeapon
    {
        private readonly IWeapon _weapon;
        
        private int _shotCounter = 10;
        private float _reloadTime = 0.0f;
        private readonly int _maxShotCount = 10;
        private readonly float _reloadCooldown = 5.0f;
        private bool _isReloading = false;

        public ReloadingWeapon(IWeapon weapon)
        {
            _weapon = weapon;
        }
        
        public void Fire()
        {
            _shotCounter--;
            
            if(CanFire())
            {
                _weapon.Fire();
                return;
            }
            
            Debug.Log("Reloading");
        }

        private bool CanFire()
        {
            var hasBullets = _shotCounter > 0;

            if (hasBullets)
            {
                return true;
            }
            
            if (!_isReloading)
            {
                _isReloading = true;
                _reloadTime = Time.time + _reloadCooldown;
            }

            if (Time.time < _reloadTime) return false;
            
            _shotCounter = _maxShotCount;
            _isReloading = false;
            _shotCounter = _maxShotCount;

            return true;
        }
    }
}