using CommandLine;
using System.Collections.Generic;

namespace SequenceJump.CLParser
{
    public class Options
    {
        public Options()
        {
            JumpSequence = new List<int>().ToArray();
        }

        [Option("difficulty", HelpText = "The lower the difficulty value is set, the difficulty is higher. Example: --difficulty=4", DefaultValue = 0)]
        public int Difficulty { get; set; }

        [Option("size", HelpText = "Sets the size of the jumping sequence. Example: --Size=25")]
        public int Size { get; set; }

        [Option("jump", Min = 1, Max = 100, HelpText = "Initialize a custom jumping sequence. Example: --jump 2 5 3 0 0 1 2 9")]
        public IEnumerable<int> JumpSequence { get; set; }
    }
}
