using System;

namespace Asteroids.BonusChain
{
    public class BonusHandler
    {
        protected readonly Ship _ship;
        private BonusHandler _nextHandler;

        public BonusHandler(Ship ship, BonusHandler nextHandler = null)
        {
            _ship = ship;
            _nextHandler = nextHandler;
        }

        public void AddNextHandler(BonusHandler nextHandler)
        {
            if (_nextHandler == null)
            {
                _nextHandler = nextHandler;
                return;
            }
            
            _nextHandler.AddNextHandler(nextHandler);
        }

        public virtual void Handle(Bonus bonus)
        {
            if (_nextHandler == null)
            {
                throw new TypeAccessException("No such bonus handler " + bonus.BonusType);
            }
            
            _nextHandler.Handle(bonus);
        }
    }
}