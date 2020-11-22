using UnityEngine;

namespace Asteroids
{
    public sealed class Ship : IMove, IRotation
    {
        private readonly IMove _moveImplementation;
        private readonly IRotation _rotationImplementation;

        private int _maxHealth;
        private int _maxArmor;

        private int _health;
        private int _armor;

        public int Health
        {
            get => _health;
            set => _health = _health + value > +_maxHealth ? _maxHealth : _health + value;
        }
        
        public int Armor
        {
            get => _armor;
            set => _armor = _armor + value > _maxArmor ? _maxArmor : _armor + value;
        }
        
        public float Speed => _moveImplementation.Speed;

        public Ship(IMove moveImplementation, IRotation rotationImplementation, int maxHealth, int maxArmor, int startHealth, int startArmor)
        {
            _moveImplementation = moveImplementation;
            _rotationImplementation = rotationImplementation;
            _maxHealth = maxHealth;
            _maxArmor = maxArmor;
            _health = startHealth;
            _armor = startArmor;
        }

        public void Move(float horizontal, float vertical, float deltaTime)
        {
            _moveImplementation.Move(horizontal, vertical, deltaTime);
        }

        public void Rotation(Vector3 direction)
        {
            _rotationImplementation.Rotation(direction);
        }

        public void AddAcceleration()
        {
            if (_moveImplementation is AccelerationMove accelerationMove)
            {
                accelerationMove.AddAcceleration();
            }
        }

        public void RemoveAcceleration()
        {
            if (_moveImplementation is AccelerationMove accelerationMove)
            {
                accelerationMove.RemoveAcceleration();
            }
        }
    }
}
