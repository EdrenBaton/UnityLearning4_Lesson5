using System.Collections.Generic;

namespace Asteroids.EnemyCompositeFactory
{
    public class CompositeFactory : IUnitFactory
    {
        private readonly List<IUnitFactory> _unitFactories;

        public CompositeFactory(List<IUnitFactory> unitFactories = null)
        {
            _unitFactories = unitFactories ?? new List<IUnitFactory>();
        }

        public bool CreateUnit(Unit unit, out Unit newUnit)
        {
            foreach (var unitFactory in _unitFactories)
            {
                if (!unitFactory.CreateUnit(unit, out var nUnit)) continue;
                newUnit = nUnit;
                return true;
            }

            newUnit = null;
            return false;
        }

        public void AddFactory(IUnitFactory unitFactory)
        {
            _unitFactories.Add(unitFactory);
        }
    }
}