namespace Asteroids.EnemyCompositeFactory
{
    public class InfantryFactory : IUnitFactory
    {
        private readonly UnitType _myType = UnitType.Infantry;

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
                Name = "Great Infabtry made by " + typeof(InfantryFactory)
            };

            return true;
        }
    }
}