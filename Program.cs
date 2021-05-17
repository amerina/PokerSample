using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace PokerSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter your choice, Sample as in the format 1,2. which means get two poker from line one.");

            Dictionary<int, int> dicPoker = new Dictionary<int, int> {
                {1,3},
                {2,5},
                {3,7}
            };

            while (dicPoker.Count > 0)
            {
                var AmerinaChoice = Console.ReadLine();

                Regex regex = new("[1-3],[1-7]");
                if (regex.IsMatch(AmerinaChoice))
                {
                    var LineNo = Convert.ToInt16(AmerinaChoice.Split(',')[0]);
                    var ChoicePoker = Convert.ToInt16(AmerinaChoice.Split(',')[1]);
                    dicPoker.TryGetValue(LineNo, out int CurrentPoker);
                    if (ChoicePoker > CurrentPoker)
                    {
                        Console.WriteLine("Poker is larger than left.");
                    }
                    else
                    {
                        dicPoker.Remove(LineNo);
                        var LeftPoker = CurrentPoker - ChoicePoker;
                        if (LeftPoker > 0)
                        {
                            dicPoker.Add(LineNo, LeftPoker);
                            Console.WriteLine($"Line {LineNo} left Poker {LeftPoker}");
                        }
                        else
                        {
                            Console.WriteLine($"Line {LineNo} left no Poker");
                            if (dicPoker.Count == 0)
                            {
                                Console.WriteLine($"You got the last poker, lucky you lost. Failure always comes to those who are prepared");
                                return;
                            }
                        }
                        Console.WriteLine("It's your turn.");
                    }
                }
                else
                {
                    Console.WriteLine("Pattern Invalid, please enter your choice, Sample as in the format 1,2 .which means get two poker from line one.");
                }
            }
        }
    }
}
