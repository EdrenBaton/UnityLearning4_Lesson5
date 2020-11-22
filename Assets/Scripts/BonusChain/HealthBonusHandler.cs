using UnityEngine;

namespace Asteroids.BonusChain
{
    public class HealthBonusHandler : BonusHandler
    {
        private readonly BonusType _myBonusType = BonusType.Health;

        public HealthBonusHandler(Ship ship, BonusHandler nextHandler = null) : base(ship, nextHandler)
        {
        }

        public override void Handle(Bonus bonus)
        {
            if(bonus.BonusType != _myBonusType)
            {
                base.Handle(bonus);
            }
            else
            {
                var currentHealth = _ship.Health;
                
                _ship.Health = bonus.BonusSize;
                Debug.Log("Ship health change from " + currentHealth + " to " + _ship.Health);
            }
        }
    }
}