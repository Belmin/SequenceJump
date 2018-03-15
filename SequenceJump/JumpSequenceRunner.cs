using System;

namespace SequenceJump
{
    public class JumpSequenceRunner
    {
        /// <summary>
        /// This method is used to start the jumping process by passing the required sequence.
        /// </summary>
        /// <param name="jumpSequence"></param>
        public static void StartJumping(int[] jumpSequence)
        {
            if (jumpSequence.Length > 0)
            {
                string exit = string.Empty;
                int[] tempSequence = jumpSequence.Clone() as int[];
                while (exit != "exit")
                {
                    Console.Clear();
                    Console.WriteLine("~~Initial Sequence: [{0}]°°GOAL°°", string.Join(", ", jumpSequence));
                    tempSequence = JumpSequenceGenerator.ReorderSequence(tempSequence);
                    Console.WriteLine("Reordered Sequence: [{0}]°°GOAL°°\n", string.Join(", ", tempSequence));
                    bool shouldIJump = RouteFinder.IsItSafeToJump(tempSequence);
                    // bool shouldIJump = RouteFinder.CheckRouteIfJumpingIsPossible(tempSequence); // Obsolete version
                    if (shouldIJump)
                    {
                        Console.WriteLine("\nCongrats!! Happy jumping :)");
                    }
                    else
                    {
                        Console.WriteLine("\nThere is no possibility to arrive to the goal!");
                    }
                    exit = Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine("Please generate a jumping sequence in order to start jumping!\n");
                Console.ReadLine();
            }
        }
    }
}
