using System;
using System.Collections.Generic;
using System.Linq;

namespace SequenceJump
{
    public class RouteFinder
    {
        /// <summary>
        /// This method is used to decide wheather you should jump to the goal or not.
        /// </summary>
        /// <param name="sequence"></param>
        /// <returns></returns>
        public static bool IsItSafeToJump(int[] sequence)
        {
            JumpParameters parameters = new JumpParameters(sequence);
            if (parameters.Solutions.Count > 0)
            {
                RouteHelper.DisplaySolutions(parameters.Solutions);
                RouteHelper.DisplayRoute(sequence);
                parameters.JumpChoice = GetToSolution(parameters, sequence);
            }
            return parameters.JumpChoice;
        }

        /// <summary>
        /// This method is used to check if it is possible to arrive to goal, and if possible, it prints out the best path.
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="sequence"></param>
        /// <returns></returns>
        private static bool GetToSolution(JumpParameters parameters, int[] sequence)
        {
            while (parameters.ArrivedToSolution != true && parameters.DeadEnd != true)
            {
                parameters.BestRoute[parameters.Position] = sequence[parameters.Position];
                parameters.JumpStrength = sequence[parameters.Position];

                if (parameters.JumpStrength > 0)
                {
                    int jump = parameters.JumpStrength + parameters.Position;
                    int initialCheck = parameters.Goal - jump;
                    // Initial jump check
                    if (initialCheck <= 0)
                    {
                        parameters.ArrivedToSolution = true;
                        DisplayBestRoute(parameters);
                        return parameters.ArrivedToSolution;
                    }
                    else
                    {
                        // Optional jump checks from current position
                        Dictionary<int, int> jumpOptions = new Dictionary<int, int>();
                        int deadEndCount = 0;
                        for (int option = jump; option >= parameters.Position + 1; option--)
                        {
                            int optionJumpStrength = sequence[option];
                            if (optionJumpStrength == 0)
                            {
                                deadEndCount++;
                                if (parameters.JumpStrength == deadEndCount)
                                {
                                    parameters.DeadEnd = true;
                                    break;
                                }
                                continue;
                            }

                            int optionalJump = optionJumpStrength + option;
                            bool checkIfSolutionFound = parameters.Solutions.ContainsKey(optionalJump);

                            if (checkIfSolutionFound)
                            {
                                parameters.BestRoute[option] = sequence[option];
                                parameters.BestRoute[optionalJump] = sequence[optionalJump];
                                parameters.Position = optionalJump;
                                parameters.JumpStrength = sequence[optionalJump];
                                parameters.ArrivedToSolution = true;
                                DisplayBestRoute(parameters);
                                break;
                            }
                            else
                            {
                                jumpOptions.Add(option, optionalJump);
                            }
                        }
                        //Jump to the best option if applicable
                        if (jumpOptions.Any())
                        {
                            parameters.Position = GetBestJumpOption(jumpOptions);
                        }
                    }
                }
            }
            return parameters.ArrivedToSolution;
        }

        /// <summary>
        /// This method returns the position that is the best option to jump on.
        /// </summary>
        /// <param name="jumpOptions"></param>
        /// <returns></returns>
        private static int GetBestJumpOption(Dictionary<int, int> jumpOptions)
        {
            int maxValue = jumpOptions.Values.Max();
            int bestOption = jumpOptions.FirstOrDefault(jumpStrength => jumpStrength.Value == maxValue).Key;
            return bestOption;
        }

        /// <summary>
        /// This method is used to show the best path to the goal.
        /// </summary>
        /// <param name="parameters"></param>
        private static void DisplayBestRoute(JumpParameters parameters)
        {
            int position = parameters.Position;
            int jumpStrength = parameters.JumpStrength;
            Console.WriteLine($"\nYou have found a way to the goal by getting " +
                                                 $"to position {position + 1} with the jump strength " +
                                                 $"of {parameters.JumpStrength}\n");
            //RouteHelper.DisplayRoute(sequence);
            Console.WriteLine("\nYou need to take the following path:\n");
            RouteHelper.DisplayRoute(parameters.BestRoute);
        }

        #region Obsolete Methods

        /// <summary>
        /// This method is used to decide wheather you could jump or not.
        /// </summary>
        /// <param name="sequence"></param>
        /// <returns></returns>
        [Obsolete]
        public static bool CheckRouteIfJumpingIsPossible(int[] sequence)
        {
            bool jumpChoice = false;
            if (sequence.Length > 0)
            {
                List<int> solutions = GetSolutionsForGoal(sequence);
                if (solutions.Count > 0)
                {
                    RouteHelper.DisplaySolutions(solutions, sequence);
                    jumpChoice = GetToGoal(solutions, sequence);
                }
            }
            return jumpChoice;
        }

        /// <summary>
        /// Get list of solutions that can get you to goal.
        /// </summary>
        /// <param name="sequence"></param>
        /// <returns></returns>
        [Obsolete]
        private static List<int> GetSolutionsForGoal(int[] sequence)
        {
            List<int> solutions = new List<int>();
            int jumpStrength = 0;
            int goal = sequence.Length;
            if (sequence[0] == 0)
            {
                return solutions;
            }
            for (int position = 0; position < sequence.Length; position++)
            {
                jumpStrength = sequence[position];
                if (jumpStrength > 0)
                {
                    int possibleSolution = goal - (jumpStrength + position);
                    if (possibleSolution <= 0)
                    {
                        solutions.Add(position);
                    }
                }
            }
            return solutions;
        }

        /// <summary>
        /// This method is used to check for the best posible path to goal. If it is possible to get to the goal this method will display the path to goal.
        /// </summary>
        /// <param name="solutions"></param>
        /// <param name="sequence"></param>
        /// <returns></returns>
        [Obsolete]
        private static bool GetToGoal(List<int> solutions, int[] sequence)
        {
            bool arrivedToSolution = false;
            int goal = sequence.Length;
            int currentPosition = 0;
            int jumpStrength = 0;
            bool deadEnd = false;
            int[] solutionRoute = new int[sequence.Length];
            while (arrivedToSolution != true && deadEnd != true)
            {
                solutionRoute[currentPosition] = sequence[currentPosition];
                jumpStrength = sequence[currentPosition];
                if (jumpStrength > 0)
                {
                    int initialCheck = goal - (jumpStrength + currentPosition);
                    if (initialCheck <= 0)
                    {
                        arrivedToSolution = true;
                        return arrivedToSolution;
                    }
                    else
                    {
                        Dictionary<int, int> jumpOptions = new Dictionary<int, int>();
                        int deadEndCount = 0;
                        for (int option = jumpStrength + currentPosition; option >= currentPosition + 1; option--)
                        {
                            int optionJumpStrength = sequence[option];
                            if (optionJumpStrength == 0)
                            {
                                deadEndCount++;
                                if (jumpStrength == deadEndCount)
                                {
                                    deadEnd = true;
                                    break;
                                }
                                continue;
                            }
                            int jump = optionJumpStrength + option;
                            List<int> checkIfSolutionFound = solutions.Where(x => jump >= x).ToList();

                            if (checkIfSolutionFound.Count > 0)
                            {
                                solutionRoute[option] = sequence[option];
                                solutionRoute[checkIfSolutionFound[0]] = sequence[checkIfSolutionFound[0]];
                                Console.WriteLine($"You have found a way to solution by getting " +
                                                  $"to position {option + 1} with the jump strength " +
                                                  $"of {optionJumpStrength}\n");
                                arrivedToSolution = true;
                                RouteHelper.DisplayRoute(sequence);
                                Console.WriteLine("\nYou need to take the following path:\n");
                                RouteHelper.DisplayRoute(solutionRoute);
                                break;
                            }
                            else
                            {
                                jumpOptions.Add(option, jump);
                            }
                        }
                        if (jumpOptions.Any())
                        {
                            int maxValue = jumpOptions.Values.Max();
                            currentPosition = jumpOptions.FirstOrDefault(x => x.Value == maxValue).Key;
                        }
                    }
                }
            }
            return arrivedToSolution;
        }

        #endregion

    }
}
