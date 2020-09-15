using System;
using System.Collections.Generic;

namespace Yatzy
{
    public class YatzyGame
    {
        public enum CATEGORY {CHANCE}
        public YatzyGame()
        {

        }

        public int CalculateScore(int[] diceRoll, string category)
        {
            switch (category)
            {
                
                case "chance":
                    int score = 0;
                    foreach(int die in diceRoll)
                    {
                        score += die;
                    }
                    return score;
                case "yatzy":
                    score = 50;
                    var sameNumber = diceRoll[0];
                    foreach(int die in diceRoll)
                    {
                        if(die != sameNumber) score = 0;
                    }
                    return score;
                case "ones":
                    score = SumBasedOnNumber(1, diceRoll);
                    return score;
                case "twos":
                    score = SumBasedOnNumber(2, diceRoll);
                    return score;
                case "threes":
                    score = SumBasedOnNumber(3, diceRoll);
                    return score;
                case "fours":
                    score = SumBasedOnNumber(4, diceRoll);
                    return score;
                case "fives":
                    score = SumBasedOnNumber(5, diceRoll);
                    return score;
                case "sixes":
                    score = SumBasedOnNumber(6, diceRoll);
                    return score;
                case "pair":
                    return FindHighestMatchingDicePair(diceRoll, 2) * 2;
                case "two pairs":
                    var twoPairs = FindTwoHighestMatchingDicePair
                    (diceRoll);
                    if (twoPairs.Count == 2)
                    {
                        return (twoPairs[0] + twoPairs[1]) * 2;
                    }
                    return 0;
                case "three of a kind":
                    return FindThreeOfAKind(diceRoll) * 3;
                default:
                    return 0;
            }
        }

        public int SumBasedOnNumber(int number, int[] diceRoll)
        {
            var score = 0;
            foreach(int die in diceRoll)
            {
                if(die == number) score += die;
            }
            return score;
        }

        public int FindHighestMatchingDicePair(int[] diceRoll, int numberOfTimes)
        {
            for(int diceNumber = 6; diceNumber > 0; diceNumber--)
            {
                var occurrence = Array.FindAll(diceRoll, die => die == diceNumber).Length;
                if (occurrence >= numberOfTimes)
                {
                    return diceNumber;
                }
            }
            return 0;
        }

        public int FindThreeOfAKind(int[] diceRoll)
        {
            for(int diceNumber = 6; diceNumber > 0; diceNumber--)
            {
                var frequency = Array.FindAll(diceRoll, die => die == diceNumber).Length;
                if (frequency > 2)
                {
                    return diceNumber;
                }
            }
            return 0;
        }

        public List<int> FindTwoHighestMatchingDicePair(int[] diceRoll)
        {
            List<int> twoHighestNumbersWithPair = new List<int>();
            for(int diceNumber = 6; diceNumber > 0; diceNumber--)
            {
                var frequency = Array.FindAll(diceRoll, die => die == diceNumber).Length;
                if (frequency > 1)
                {
                    twoHighestNumbersWithPair.Add(diceNumber);
                }
                if (twoHighestNumbersWithPair.Count == 2)
                {
                    return twoHighestNumbersWithPair;
                }
            }
            return twoHighestNumbersWithPair;
        }
    }
}