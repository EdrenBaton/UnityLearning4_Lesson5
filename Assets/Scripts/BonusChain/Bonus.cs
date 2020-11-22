namespace Asteroids.BonusChain
{
    public class Bonus
    {
        public BonusType BonusType;
        public int BonusSize;

        public Bonus(BonusType bonusType, int bonusSize)
        {
            BonusType = bonusType;
            BonusSize = bonusSize;
        }
    }
}