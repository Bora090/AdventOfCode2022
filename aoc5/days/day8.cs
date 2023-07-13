using System.Collections.Generic;
using System.Linq;

namespace aoc5.days
{
    [Comment("Day 8: Treetop Tree House")]
    public class day8 : aocEvent
    {
        public day8(IInputFileService inputFileService) : base("day8", inputFileService)
        {
            IEnumerable<List<byte>> rows = standardInput.Select(treeRow => treeRow.ToArray().Select(tree => byte.Parse(tree.ToString())).ToList());

        }
        public void test()
        {

        }
    }
}
