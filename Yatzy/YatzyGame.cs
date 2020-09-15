using System;
using System.Collections.Generic;
using System.Linq;

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
                    return SumDiceRoll(diceRoll);
                case "yatzy":
                    int score = 50;
                    var sameNumber = diceRoll[0];
                    foreach(int die in diceRoll)
                    {
                        if(die != sameNumber) score = 0;
                    }
                    return score;
                case "ones":
                    return SumBasedOnNumber(1, diceRoll);
                case "twos":
                    return SumBasedOnNumber(2, diceRoll);
                case "threes":
                    return SumBasedOnNumber(3, diceRoll);
                case "fours":
                    return SumBasedOnNumber(4, diceRoll);
                case "fives":
                    return SumBasedOnNumber(5, diceRoll);
                case "sixes":
                    return SumBasedOnNumber(6, diceRoll);
                case "pair":
                    return FindHighestMatchingDiceForGivenFrequency(diceRoll, 2) * 2;
                case "two pairs":
                    var twoPairs = FindTwoHighestMatchingDicePair
                    (diceRoll);
                    if (twoPairs.Count == 2)
                    {
                        return (twoPairs[0] + twoPairs[1]) * 2;
                    }
                    return 0;
                case "three of a kind":
                    return FindHighestMatchingDiceForGivenFrequency(diceRoll, 3) * 3;
                case "four of a kind":
                    return FindHighestMatchingDiceForGivenFrequency(diceRoll, 4) * 4;
                case "small straight":
                    if (isSmallStraight(diceRoll)) return 15;
                    return 0;
                case "large straight":
                    if (isLargeStraight(diceRoll)) return 20;
                    return 0;
                case "full house":
                    if(isFullHouse(diceRoll))
                    {
                        return SumDiceRoll(diceRoll);
                    }
                    return 0;
                default:
                    return 0;
            }
        }

        public bool isFullHouse(int[] diceRoll)
        {
            var diceRollDictionary = ConvertToDictionary(diceRoll);
            var conditionForFullHouse = diceRollDictionary.Keys.Count == 2 && diceRollDictionary.Values.Min() > 1;
            return (conditionForFullHouse) ? true : false;
        }

        public Dictionary<int,int> ConvertToDictionary(int[] diceRoll)
        {
            var dictionary = new Dictionary<int,int>();
            foreach(int die in diceRoll)
            {
                if(dictionary.ContainsKey(die))
                {
                    dictionary[die] = dictionary[die] + 1;
                }
                else
                {
                    dictionary.Add(die, 1);
                }
            }
            return dictionary;
        }

        public bool isSmallStraight(int[] diceRoll)
        {
            int[] smallStraight = new int[5] {1,2,3,4,5};
            return diceRoll.SequenceEqual(smallStraight);
        }

        public bool isLargeStraight(int[] diceRoll)
        {
            int[] largeStraight = new int[5] {2,3,4,5,6};
            return diceRoll.SequenceEqual(largeStraight);
        }

        public int SumDiceRoll(int[] diceRoll)
        {
            int score = 0;
            foreach(int die in diceRoll)
            {
                score += die;
            }
            return score;
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

        public int FindHighestMatchingDiceForGivenFrequency(int[] diceRoll, int numberOfTimes)
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