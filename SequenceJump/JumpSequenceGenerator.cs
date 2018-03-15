using System;

namespace SequenceJump
{
    public class JumpSequenceGenerator
    {
        /// <summary>
        /// This method is used to randomly reorder the passed sequence.
        /// </summary>
        /// <param name="sequence"></param>
        /// <returns></returns>
        public static int[] ReorderSequence(int[] sequence)
        {
            for (int i = 0; i < sequence.Length; i++)
            {
                int randomIndex = SequenceHelpers.GetRandomNumber(sequence.Length);
                int oldPositionValue = sequence[i];
                int newPositionValue = sequence[randomIndex];
                sequence[randomIndex] = oldPositionValue;
                sequence[i] = newPositionValue;
            }
            return sequence;
        }

        /// <summary>
        /// This method is used to generate a random jump sequence by passing the wanted sequence size and difficulty as parameters.
        /// </summary>
        /// <param name="numberOfElements"></param>
        /// <param name="difficulty"></param>
        /// <returns></returns>
        public static int[] GetRandomJumpSequence(int numberOfElements, int difficulty = 0)
        {
            Random rand = new Random();
            int max = numberOfElements;
            int[] jumpSequence = new int[numberOfElements];
            if (difficulty > 0 && difficulty <= numberOfElements)
            {
                max = difficulty + 1;
            }
            for (int i = 0; i < jumpSequence.Length; i++)
            {
                jumpSequence[i] = rand.Next(0, max);
            }
            return jumpSequence;
        }
    }
}
