using System.Collections.Generic;
using System.Linq;

namespace aoc5.days
{
    class move
    {
        public int amount { get; set; }
        public int from { get; set; }
        public int to { get; set; }
    }

    [Comment("Day 5: Supply Stacks")]
    public class day5 : aocEvent
    {
        public day5(IInputFileService inputFileService) : base("day5", inputFileService)
        {
            IEnumerable<string> rawMoves = standardInput.Where(x => x.StartsWith("move")); //ex, move 7 from 3 to 9
            moves = rawMoves.Select(x => new move
            {
                amount = int.Parse(x.Split(" ")[1]),
                from = int.Parse(x.Split(" ")[3]) - 1, ///to everything because these people do not believe in index 0 cuz theyre elfs
                to = int.Parse(x.Split(" ")[5]) - 1
            });
            IEnumerable<IEnumerable<char>> cratesHorizontal = standardInput.Where(x => x.Trim().StartsWith("[")).Select(x => x.Chunk(4).Select(x => x[1]));
            crates = convertRowsToVertical(cratesHorizontal);
            crates = crates.Select(x => x.Where(x => x != ' ').ToList()).ToList(); //remove empty entries

        }
        private IEnumerable<move> moves { get; set; }
        private List<List<char>> crates { get; set; }

        public string crateMover9000()
        {
            List<List<char>> _crates = crates.Select(x => x.ToList()).ToList();

            foreach (move _move in moves)
            {
                for (int i = 0; i < _move.amount; i++)
                {
                    _crates[_move.to].Add(_crates[_move.from].Pop());
                }
            }
            return getTopFromEachRow(_crates);
        }
        public string crateMover9001()
        {
            List<List<char>> _crates = crates.Select(x => x.ToList()).ToList();
            foreach (move _move in moves)
            {
                List<char> stack = new List<char>();
                for (int i = 0; i < _move.amount; i++)
                {
                    stack.Add(_crates[_move.from].Pop());
                }
                stack.Reverse();
                _crates[_move.to].AddRange(stack);
                stack.Clear();
            }
            return getTopFromEachRow(_crates);
        }
        private string getTopFromEachRow(List<List<char>> cratesList)
        {
            string topOfEachRow = "";
            foreach (List<char> row in cratesList)
            {
                topOfEachRow += row.Last();
            }
            return topOfEachRow;
        }

        private List<List<char>> convertRowsToVertical(IEnumerable<IEnumerable<char>> rowsHorizontal)
        {
            List<List<char>> rowsVertical = new List<List<char>>();
            List<List<char>> lRowsHorizontal = rowsHorizontal.Select(x => x.ToList()).ToList(); //convert the IEnumerable<IEnumerable<char>> to list
            for (int value = 0; value < 9; value++) //rows will always have a length of 9 horizontally so we can hardcode this
            {
                List<char> verticalRow = new List<char>();
                for (int row = 0; row < lRowsHorizontal.Count(); row++) //get the horizontal rows length
                {
                    verticalRow.Add(lRowsHorizontal[row][value]); //we get the next value of every row
                }
                verticalRow.Reverse(); ///reverse the values so they are correctly vertical and not upside down
                rowsVertical.Add(verticalRow);
            }
            return rowsVertical;
        }
    }
}
