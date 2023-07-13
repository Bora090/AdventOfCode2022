using System.Collections.Generic;
using System.Linq;
using System;

namespace aoc5.days
{
    public enum eShape : byte
    {
        Rock = 1,
        Paper,
        Scissors,
        Invalid = 255, //never returned
    }
    public enum eOutcome : byte
    {
        Loss,
        Draw = 3,
        Win = 6,
        Invalid = 255,
    }

    [Comment("Day 2: Rock Paper Scissors")]
    public class day2 : aocEvent
    {
        public day2(IInputFileService inputFileService) : base("day2", inputFileService)
        {
            inputGames = standardInput.Select(x => x.Split(" "));
        }
        public IEnumerable<IEnumerable<string>> inputGames { get; set; }
        private eShape choiceToShape(string choice)
        {
            switch (choice)
            {
                case "A":
                case "X":
                    return eShape.Rock;
                case "B":
                case "Y":
                    return eShape.Paper;
                case "C":
                case "Z":
                    return eShape.Scissors;
                default: //for some reason default is always needed this should however never be returned
                    return eShape.Invalid;
            }
        }
        private eOutcome choiceToOutcome(string choice)
        {
            switch (choice)
            {
                case "X":
                    return eOutcome.Loss;
                case "Y":
                    return eOutcome.Draw;
                case "Z":
                    return eOutcome.Win;
                default: //for some reason default is always needed this should however never be returned
                    return eOutcome.Invalid;
            }
        }
        private eOutcome calculateOutcome(eShape oppShape, eShape userShape)
        {
            if (oppShape == userShape)
            {
                return eOutcome.Draw;
            }
            if (oppShape == eShape.Rock && userShape == eShape.Scissors || oppShape == eShape.Paper && userShape == eShape.Rock || oppShape == eShape.Scissors && userShape == eShape.Paper)
            {
                return eOutcome.Loss;
            }
            return eOutcome.Win;
        }
        private eShape bruteforceShapeForOutcome(eShape oppShape, eOutcome outcomeWanted)
        {
            foreach (eShape shape in Enum.GetValues(typeof(eShape)))
            {
                if (calculateOutcome(oppShape, shape) == outcomeWanted)
                {
                    return shape;
                }
            }
            return eShape.Invalid;
        }
        public int getAccordingToPlanTotal()
        {
            int total = 0;
            foreach (var game in inputGames)
            {
                eShape oppChoice = choiceToShape(game.ToList()[0]);
                eShape userChoice = choiceToShape(game.ToList()[1]);
                total += (int)userChoice;
                total += (int)calculateOutcome(oppChoice, userChoice);

            }
            return total;
        }
        public int getAccordingToElfTotal()
        {
            int total = 0;
            foreach (var game in inputGames)
            {
                eShape oppChoice = choiceToShape(game.ToList()[0]);
                eShape userChoice = bruteforceShapeForOutcome(oppChoice, choiceToOutcome(game.ToList()[1]));
                total += (int)userChoice;
                total += (int)calculateOutcome(oppChoice, userChoice);
            }
            return total;
        }

    }
}
