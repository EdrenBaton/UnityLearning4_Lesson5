using Asteroids.BonusChain;
using Asteroids.WeaponLocker;
using UnityEngine;

namespace Asteroids
{
    internal sealed class Player : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _acceleration;
        [SerializeField] private float _hp;
        [SerializeField] private Rigidbody2D _bullet;
        [SerializeField] private Transform _barrel;
        [SerializeField] private float _force;
        [SerializeField] private int _maxHp;
        [SerializeField] private int _maxArmor;
        [SerializeField] private int _startHealth;
        [SerializeField] private int _stratArmor;
        
        private Camera _camera;
        private Ship _ship;
        private IWeapon _weapon;
        private IWeapon _reloadingWeapon;

        private ScoreIntepreter.ScoreInterpreter _scoreIntepreter;

        private void Start()
        {
            _camera = Camera.main;
            var moveTransform = new AccelerationMove(transform, _speed, _acceleration);
            var rotation = new RotationShip(transform);
            _ship = new Ship(moveTransform, rotation, _maxHp, _maxArmor, _startHealth, _stratArmor);
            _weapon = new BarrelWeapon(_barrel, _bullet, _force);
            _reloadingWeapon = new ReloadingWeapon(_weapon);

            _scoreIntepreter = new ScoreIntepreter.ScoreInterpreter();
            
            var bonusChain = new ArmorHandler(_ship, new HealthBonusHandler(_ship));
            bonusChain.Handle(new Bonus(BonusType.Health, 10));
            bonusChain.Handle(new Bonus(BonusType.Armor, 50));
            bonusChain.Handle(new Bonus(BonusType.Health, 25));
            bonusChain.Handle(new Bonus(BonusType.Speed, 25));
        }

        private void Update()
        {
            var direction = Input.mousePosition - _camera.WorldToScreenPoint(transform.position);
            _ship.Rotation(direction);

            _ship.Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), Time.deltaTime);

            if (Input.GetKeyDown(KeyCode.LeftShift)) _ship.AddAcceleration();

            if (Input.GetKeyUp(KeyCode.LeftShift)) _ship.RemoveAcceleration();

            if (Input.GetButtonDown("Fire1"))
            {
                _reloadingWeapon.Fire();
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log(_scoreIntepreter.GetLetter());
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (_hp <= 0)
                Destroy(gameObject);
            else
                _hp--;
        }
    }
}