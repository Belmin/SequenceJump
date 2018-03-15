using System;

namespace SequenceJump
{
    public class SequenceHelpers
    {
        /// <summary>
        /// This method is returning a random number from 0 to the passed max parameter.
        /// </summary>
        /// <param name="max"></param>
        /// <returns></returns>
        public static int GetRandomNumber(int max)
        {
            Random rand = new Random();
            double num = rand.NextDouble() * max;
            int result = (int)Math.Floor(num);
            return result;
        }
    }
}
