using System;
using System.Collections.Generic;
using System.Linq;

namespace SequenceJump
{
    public class RouteHelper
    {
        private const string spaceDelimeter = " ";
        private const string JumpStrengthElement = "III" + spaceDelimeter;
        private const string BlankElement = "---" + spaceDelimeter;
        private const string GoalElement = "^~^°^~GOAL~^~^~^";

        /// <summary>
        /// This method is used to generate a simple route view from the passed sequence.
        /// </summary>
        /// <param name="sequence"></param>
        public static void DisplayRoute(int[] jumpSequence)
        {
            Console.WriteLine("||===========RoutView===========||\n");
            int[] tempSequence = jumpSequence.Clone() as int[];
            int sequenceLength = tempSequence.Length;
            int elementSize = JumpStrengthElement.Length;
            int groundLine = sequenceLength * elementSize;
            bool arrivedAtGoal = false;

            while (arrivedAtGoal != true)
            {
                int maxValue = tempSequence.Max();
                for (int i = 0; i < sequenceLength; i++)
                {
                    if (tempSequence[i] == maxValue)
                    {
                        Console.Write(JumpStrengthElement);
                        tempSequence[i] = tempSequence[i] - 1;
                    }
                    else
                    {
                        Console.Write(BlankElement);
                    }
                }
                if (tempSequence.Max() == 0)
                {
                    Console.WriteLine(GoalElement);
                    arrivedAtGoal = true;
                    for (int i = 1; i <= groundLine; i++)
                    {
                        if (i % elementSize == 0)
                        {
                            int elementPosition = i / elementSize;
                            if (elementPosition > 9)
                            {
                                Console.Write($"{elementPosition}__");
                            }
                            else
                            {
                                Console.Write($"_{elementPosition}__");
                            }
                        }
                    }
                    break;
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        /// <summary>
        /// This method is used to display all solutions that could lead you to goal.
        /// </summary>
        /// <param name="solutions"></param>
        public static void DisplaySolutions(List<int> solutions, int[] sequence)
        {
            Console.WriteLine("Possible solutions: ");
            for (int i = 0; i < solutions.Count; i++)
            {
                Console.WriteLine($"\tPosition: {solutions[i]}; JumpStrength: {sequence[i]};");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// This method is used to display all solutions that could lead you to goal.
        /// </summary>
        /// <param name="solutions"></param>
        public static void DisplaySolutions(Dictionary<int, int> solutions)
        {
            Console.WriteLine("Possible solutions: ");
            foreach (int position in solutions.Keys)
            {
                Console.WriteLine($"\tPosition: {position + 1}; JumpStrength: {solutions[position]};");
            }
            Console.WriteLine();
        }
    }
}
