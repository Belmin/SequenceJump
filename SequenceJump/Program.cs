using CommandLine;
using SequenceJump.CLParser;

namespace SequenceJump
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser parser = new Parser(with => with.EnableDashDash = true);
            ParserResult<Options> parserResult = parser.ParseArguments<Options>(args);
            int[] jumpSequence = parserResult.Value.JumpSequence as int[];

            if (jumpSequence.Length == 0)
            {
                jumpSequence = JumpSequenceGenerator.GetRandomJumpSequence(parserResult.Value.Size, parserResult.Value.Difficulty);
            }

            JumpSequenceRunner.StartJumping(jumpSequence);
        }
    }
}
