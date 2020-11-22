using System;

namespace Asteroids.ScoreIntepreter
{
    public class ScoreInterpreter
    {
        private long currentValue = 1;

        public string GetLetter()
        {
            currentValue *= 2;
            
            if (currentValue < 1) throw new ArgumentOutOfRangeException("Input number greater than 0");

            var strValue = currentValue.ToString().Length;

            if (strValue > 12) throw new ArgumentOutOfRangeException(currentValue + " is incredible big");
            if (strValue > 9) return currentValue / 1000000000 + "B";
            if (strValue > 6) return currentValue / 1000000 + "M";
            if (strValue > 3) return currentValue / 1000 + "k";
            
            return currentValue.ToString();
        }
    }
}