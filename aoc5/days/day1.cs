using System.Collections.Generic;
using System.Linq;

namespace aoc5.days
{
    [Comment("Day 1: Calorie Counting")]
    public class day1 : aocEvent
    {
        public day1(IInputFileService inputFileService) : base("day1", inputFileService)
        {
            var input = getInputs($"{lineSplitter}{lineSplitter}");
            inputSums = input.Select(x => x.Split(lineSplitter).Select(int.Parse).Sum());
        }
        public IEnumerable<int> inputSums { get; set; }

        public int getElfMostCaloriesTotal()
        {
            return inputSums.Max();
        }

        public int getTop3ElfsTotal()
        {
            return inputSums.OrderByDescending(num => num).Take(3).Sum();
        }
    }
}
