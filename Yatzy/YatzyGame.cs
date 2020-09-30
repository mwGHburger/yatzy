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

        public int CalculateScoreGivenCategory(int[] diceRoll, string category)
        {
            switch (category)
            {
                case "chance":
                    return SumDiceRoll(diceRoll);
                case "yatzy":
                    return isYatzy(diceRoll) ? 50 : 0;
                case "ones":
                    return SumTheDieNumber(1, diceRoll);
                case "twos":
                    return SumTheDieNumber(2, diceRoll);
                case "threes":
                    return SumTheDieNumber(3, diceRoll);
                case "fours":
                    return SumTheDieNumber(4, diceRoll);
                case "fives":
                    return SumTheDieNumber(5, diceRoll);
                case "sixes":
                    return SumTheDieNumber(6, diceRoll);
                case "pair":
                    var frequency = 2;
                    return SumDieNumberGivenFrequency(diceRoll, frequency);
                case "two pairs":
                    return SumOfTwoHighestPairs(diceRoll);
                case "three of a kind":
                    frequency = 3;
                    return SumDieNumberGivenFrequency(diceRoll, frequency);
                case "four of a kind":
                    frequency = 4;
                    return SumDieNumberGivenFrequency(diceRoll, frequency);
                case "small straight":
                    return isSmallStraight(diceRoll) ? 15 : 0;
                case "large straight":
                    return isLargeStraight(diceRoll) ? 20 : 0;
                case "full house":
                    return isFullHouse(diceRoll) ? SumDiceRoll(diceRoll) : 0;
                default:
                    return 0;
            }
        }

        private int SumOfTwoHighestPairs(int[] diceRoll)
        {
            var twoPairs = CreateListOfTwoHighestMatchingDicePair(diceRoll);
            return (twoPairs.Count == 2) ? (twoPairs[0] + twoPairs[1]) * 2 : 0;
        }

        private bool isYatzy(int[] diceRoll)
        {
            var sameNumber = diceRoll[0];
            foreach(int die in diceRoll)
            {
                if(die != sameNumber) return false;
            }
            return true;
        }

        private bool isFullHouse(int[] diceRoll)
        {
            var diceRollDictionary = ConvertToDictionary(diceRoll);
            var conditionForFullHouse = diceRollDictionary.Keys.Count == 2 && diceRollDictionary.Values.Min() > 1;
            return (conditionForFullHouse) ? true : false;
        }

        private Dictionary<int,int> ConvertToDictionary(int[] diceRoll)
        {
            var diceRollDictionary = new Dictionary<int,int>();
            foreach(int die in diceRoll)
            {
                if(diceRollDictionary.ContainsKey(die))
                {
                    diceRollDictionary[die] = diceRollDictionary[die] + 1;
                }
                else
                {
                    diceRollDictionary.Add(die, 1);
                }
            }
            return diceRollDictionary;
        }

        private bool isSmallStraight(int[] diceRoll)
        {
            int[] smallStraight = new int[5] {1,2,3,4,5};
            return diceRoll.SequenceEqual(smallStraight);
        }

        private bool isLargeStraight(int[] diceRoll)
        {
            int[] largeStraight = new int[5] {2,3,4,5,6};
            return diceRoll.SequenceEqual(largeStraight);
        }

        private int SumDiceRoll(int[] diceRoll)
        {
            int score = 0;
            foreach(int die in diceRoll)
            {
                score += die;
            }
            return score;
        }
        private int SumTheDieNumber(int number, int[] diceRoll)
        {
            var score = 0;
            foreach(int die in diceRoll)
            {
                if(die == number) score += die;
            }
            return score;
        }

        private int SumDieNumberGivenFrequency(int[] diceRoll, int frequency)
        {
            var dieNumber = FindHighestMatchingDiceGivenFrequency(diceRoll, frequency);
            return dieNumber * frequency;
        }

        private int FindHighestMatchingDiceGivenFrequency(int[] diceRoll, int numberOfTimes)
        {
            for(int diceNumber = 6; diceNumber > 0; diceNumber--)
            {
                var occurrence = Array.FindAll(diceRoll, die => die == diceNumber).Length;
                if (occurrence >= numberOfTimes) return diceNumber;
            }
            return 0;
        }

        private List<int> CreateListOfTwoHighestMatchingDicePair(int[] diceRoll)
        {
            List<int> twoHighestNumbersWithPair = new List<int>();
            for(int diceNumber = 6; diceNumber > 0; diceNumber--)
            {
                var frequency = Array.FindAll(diceRoll, die => die == diceNumber).Length;
                if (frequency > 1) twoHighestNumbersWithPair.Add(diceNumber);
                if (twoHighestNumbersWithPair.Count == 2) return twoHighestNumbersWithPair;
            }
            return twoHighestNumbersWithPair;
        }
    }
}