using aoc5.days;
using System.Linq;
using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace aoc5
{
    using iAocFuncList = List<Func<int>>;
    using sAocFuncList = List<Func<string>>;

    internal class Program
    {
        static void Main(string[] args)
        {
            inputFileService inputFileService = new inputFileService();
            Dictionary<string, object> aocEventDays = new Dictionary<string, object>();

            day1 day1 = new day1(inputFileService); //todo profile these constructors and use Custom "Comment" Attribute
            day2 day2 = new day2(inputFileService);
            day3 day3 = new day3(inputFileService);
            day4 day4 = new day4(inputFileService);
            day5 day5 = new day5(inputFileService);
            day6 day6 = new day6(inputFileService);

            #region Profiling Functions
            var puzzles = new Dictionary<string, dynamic>()
            {
                {"Day 1: Calorie Counting", new iAocFuncList(){
                    day1.getElfMostCaloriesTotal,
                    day1.getTop3ElfsTotal}
                },
                { "Day 2: Rock Paper Scissors", new iAocFuncList(){
                    day2.getAccordingToPlanTotal,
                    day2.getAccordingToElfTotal}
                },
                {"Day 3: Rucksack Reorganization", new iAocFuncList(){
                    day3.getRugsackContainerDupeSums,
                    day3.getGroupBadgeSum}
                },
                {"Day 4: Camp Cleanup", new iAocFuncList(){
                    day4.getNumRangesFullyContainingOthers,
                    day4.getNumOverlappingRanges}
                },
                {"Day 5: Supply Stacks", new sAocFuncList(){
                    day5.crateMover9000,
                    day5.crateMover9001}
                },
                {"Day 6: Tuning Trouble", new iAocFuncList(){
                    day6.getProcessedBeforeSOP,
                    day6.getProcessedBeforeSOM}
                },
            };

            foreach (var puzzle in puzzles)
            {
                Console.WriteLine(puzzle.Key);
                foreach (var func in puzzle.Value)
                {

                    List<long> elapseTimes = new List<long>();
                    object funcResult = null;
                    for (int i = 0; i < 500; i++)
                    {
                        Stopwatch watch = Stopwatch.StartNew();
                        funcResult = func();
                        watch.Stop();
                        if (watch.ElapsedMilliseconds > 0.00)
                            elapseTimes.Add(watch.ElapsedMilliseconds);
                    }
                    if (elapseTimes.Count == 0)
                        elapseTimes.Add(1);

                    Console.WriteLine($"    {func.Method.Name}: {funcResult.ToString()} (AVG {Math.Round(elapseTimes.Average(), 4)}ms HIGH {elapseTimes.Max()}ms)");
                }
            }
            #endregion
            Console.Read();
        }
    }
}
