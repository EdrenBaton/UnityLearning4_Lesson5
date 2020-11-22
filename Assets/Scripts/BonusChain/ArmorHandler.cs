using UnityEngine;

namespace Asteroids.BonusChain
{
    public class ArmorHandler : BonusHandler
    {
        private readonly BonusType _myBonusType = BonusType.Armor;
        
        public ArmorHandler(Ship ship, BonusHandler nextHandler = null) : base(ship, nextHandler)
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
                var currentArmor = _ship.Armor;
                
                _ship.Armor = bonus.BonusSize;
                
                _ship.Health = bonus.BonusSize;
                Debug.Log("Ship armor change from " + currentArmor + " to " + _ship.Armor);
            }
        }
    }
}