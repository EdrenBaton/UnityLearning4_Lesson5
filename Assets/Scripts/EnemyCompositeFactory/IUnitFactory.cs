namespace Asteroids.EnemyCompositeFactory
{
    public interface IUnitFactory
    {
        bool CreateUnit(Unit unit, out Unit newUnit);
    }
}