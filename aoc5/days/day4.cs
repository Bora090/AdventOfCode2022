using System.Collections.Generic;
using System.Linq;

namespace aoc5.days
{

    [Comment("Day 4: Camp Cleanup")]
    public class day4 : aocEvent //--- Day 4: Camp Cleanup ---
    {
        public day4(IInputFileService inputFileService) : base("day4", inputFileService)
        {
            sectionRanges = standardInput.Select(
                x => x.Split(",").Select(x => x.Split("-").Select(int.Parse)).ToArray()
            ); //split ex, "51-73,50-52" into a int array containing min,max for both ranges
        }
        private IEnumerable<IEnumerable<int>[]> sectionRanges { get; set; } //array containing 2 arrays which members are min/max

        public int getNumRangesFullyContainingOthers()
        {
            int count = 0;
            foreach (var ranges in sectionRanges)
            {
                int[] rangeFirst = ranges[0].ToArray();
                int[] rangeSecond = ranges[1].ToArray();
                if (rangeSecond[0] /* min */ >= rangeFirst[0] /* max */ && rangeSecond[1] /* max */ <= rangeFirst[1] /* max */)
                {
                    count++;
                }
                else if (rangeFirst[0] /* min */ >= rangeSecond[0] /* max */ && rangeFirst[1] /* max */ <= rangeSecond[1] /* max */)
                {
                    count++;
                }
            }
            return count;

        }
        public int getNumOverlappingRanges()   ////definitely dry violations TODO fix
        {
            int count = 0;
            foreach (var ranges in sectionRanges)
            {
                int[] rangeFirst = ranges[0].ToArray();
                int[] rangeSecond = ranges[1].ToArray();
                List<List<int>> lRanges = new List<List<int>>
                {
                    new List<int> { },
                    new List<int> { }
                };

                for (int i = rangeFirst[0] /* min */; i < rangeFirst[1] + 1/* max */; i++)
                {
                    lRanges[0].Add(i);
                }
                for (int i = rangeSecond[0] /* min */; i < rangeSecond[1] + 1 /* max */; i++)
                {
                    lRanges[1].Add(i);
                }

                foreach (var x in lRanges.Select(i => i.Where(i => lRanges[0].Contains(i) && lRanges[1].Contains(i))))
                {
                    if (x.Any())
                    { //if there a number that is in both rnages
                        count++;
                    }
                    break;

                }
            }
            return count;
        }
    }
}
