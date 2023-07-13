using System.Collections.Generic;
using System.Linq;
using System;
using System.Data;

namespace aoc5.days
{
    [Comment("Day 3: Rucksack Reorganization")]
    public class day3 : aocEvent
    {
        public day3(IInputFileService inputFileService) : base("day3", inputFileService)
        {
            int i = 0;
            rugsacksGroups = standardInput.Select(
                x => x.Select(x => getCharPriority(x))  //For all the strings convert them to a char by looping through the string then get the prio
           ).GroupBy(s => i++ / 3).Select(group => group.ToArray()); //Group into groups of 3 but convert them into arrays cuz fuck groups


            rugsackContainers = standardInput.Select(
                x => new[] { //Split the string into half (2 containers) and get both values in an array
                    x.Substring(0, x.Length/2).Select(x => getCharPriority(x)),  //then convert that string array to a array of char priorities
                    x.Substring(x.Length/2, x.Length-x.Length/2).Select(x => getCharPriority(x))
                }
            );
        }
        private IEnumerable<IEnumerable<int>[]> rugsackContainers { get; set; } //rugsack containers contain priority part 1
        private IEnumerable<IEnumerable<int>[]> rugsacksGroups { get; set; } //groups of 3 rugsacks
        private int getCharPriority(char character) //https://www.rapidtables.com/code/text/ascii-table.html
        {
            byte asciiChar = (byte)character;
            return asciiChar >= 97 ? asciiChar - 96 : asciiChar - 38;
        }
        public int getRugsackContainerDupeSums()
        {
            int prioritySharedSum = 0;

            foreach (var rugsack in rugsackContainers)
            {
                int[] containerFirst = rugsack[0].Distinct().ToArray(); //Grabs the first container (first half) and removes the duplicate values in the array)
                int[] containerSecond = rugsack[1].Distinct().ToArray();
                foreach (int prio in containerFirst.Where(prio => containerSecond.Contains(prio))) //if prio is in both containers
                {
                    prioritySharedSum += prio;
                }
            }
            return prioritySharedSum;
        }

        public int getGroupBadgeSum()
        {
            int groupBadgeSum = 0;

            foreach (var rugsack in rugsacksGroups)
            {
                int[] rugsackFirst = rugsack[0].Distinct().ToArray(); //Grabs the first rugsack (first half) and removes the duplicate values in the array)
                int[] rugsackSecond = rugsack[1].Distinct().ToArray();
                int[] rugsackThird = rugsack[2].Distinct().ToArray();

                foreach (int prio in rugsackFirst.Where(prio => rugsackSecond.Contains(prio) && rugsackThird.Contains(prio))) //if prio is in all 3 contaners
                {
                    groupBadgeSum += prio;
                    break;
                }
            }
            return groupBadgeSum;
        }
    }
}
