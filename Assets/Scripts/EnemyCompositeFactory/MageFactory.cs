namespace Asteroids.EnemyCompositeFactory
{
    public class MageFactory : IUnitFactory
    {
        private readonly UnitType _myType = UnitType.Mage;

        public bool CreateUnit(Unit unit, out Unit newUnit)
        {
            if (unit.Type != _myType)
            {
                newUnit = null;
                return false;
            }

            newUnit = new Unit
            {
                Health = unit.Health,
                Type = unit.Type,
                Name = "Wise mage made by " + typeof(MageFactory)
            };

            return true;
        }
    }
}