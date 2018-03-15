using System.Collections.Generic;
using System.Linq;

namespace SequenceJump
{
    public class JumpParameters
    {
        public JumpParameters()
        {
            Solutions = new Dictionary<int, int>();
            BestRoute = new int[] { };
        }

        public JumpParameters(int[] jumpSequence)
        {
            JumpStrength = jumpSequence.FirstOrDefault();
            Goal = jumpSequence.Length;
            Solutions = GetSolutions(jumpSequence);
            BestRoute = new int[Goal];
        }

        public int JumpStrength { get; set; }

        public int Position { get; set; }

        public int Goal { get; set; }

        public bool JumpChoice { get; set; }

        public bool ArrivedToSolution { get; set; }

        public bool DeadEnd { get; set; }

        public int[] BestRoute { get; set; }

        public Dictionary<int, int> Solutions { get; set; }

        private Dictionary<int, int> GetSolutions(int[] jumpSequence)
        {
            Dictionary<int, int> solutions = new Dictionary<int, int>();
            if (JumpStrength == 0)
            {
                return solutions;
            }
            if (Goal > 0)
            {
                for (int position = 0; position < Goal; position++)
                {
                    int jumpStrength = jumpSequence[position];
                    if (jumpStrength > 0)
                    {
                        int jump = jumpStrength + position;
                        int possibleSolution = Goal - jump;
                        if (possibleSolution <= 0)
                        {
                            solutions.Add(position, jumpStrength);
                        }
                    }
                }
            }
            return solutions;
        }
    }
}
