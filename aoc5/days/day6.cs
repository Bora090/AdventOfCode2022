using System.Collections.Generic;
using System.Linq;

namespace aoc5.days
{
    [Comment("Day 6: Tuning Trouble")]
    public class day6 : aocEvent
    {
        public day6(IInputFileService inputFileService) : base("day6", inputFileService)
        {
            buffer = getInputs().ToArray()[0];
        }
        public string buffer { get; set; }
        private int getFirstMarkerAfter(int distinctCharacters)
        {
            int charactersProcessed = 0;
            for (int i = 0; i < buffer.Length - (distinctCharacters - 1); i++) //-1 because they dont believe in index 0
            {
                string characters = buffer.Substring(i, distinctCharacters);
                //string uniqueCharacters = new string(characters.ToCharArray().Distinct().ToArray());
                HashSet<char> uniqueCharacters = new HashSet<char>(characters); //this is faster then above solution
                if (uniqueCharacters.Count == characters.Length)
                {
                    charactersProcessed = i + distinctCharacters;
                    break;
                }
            }
            return charactersProcessed;
        }
        public int getProcessedBeforeSOP()
        {
            return getFirstMarkerAfter(4);
        }
        public int getProcessedBeforeSOM()
        {
            return getFirstMarkerAfter(14);
        }
    }
}
