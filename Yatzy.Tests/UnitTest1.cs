using System;
using Xunit;

namespace Yatzy.Tests
{
    public class DiceScoreShould
    {
        
        [Fact]
        public void ReturnScoreForChance()
        {
            var yatzy = new YatzyGame();
            var diceRoll1 = new int[5] {1,1,3,3,6};
            var diceRoll2 = new int[5] {4,5,5,6,1};
            var category = "chance";
            var expectedScore1 = 14;
            var expectedScore2 = 21;
            
            var actualScore1 = yatzy.CalculateScore(diceRoll1, category);
            var actualScore2 = yatzy.CalculateScore(diceRoll2, category);

            Assert.Equal(expectedScore1, actualScore1);
            Assert.Equal(expectedScore2, actualScore2);
        }

        [Fact]
        public void ReturnScoreForYatzy()
        {
            var yatzy = new YatzyGame();
            var diceRollPass = new int[] {1,1,1,1,1,1};
            var diceRollFail = new int[] {1,1,1,1,2,1};
            var category = "yatzy";
            var expectedScorePass = 50;
            var expectedScoreFail = 0;

            var actualScorePass = yatzy.CalculateScore(diceRollPass, category);
            var actualScoreFail = yatzy.CalculateScore(diceRollFail,category);

            Assert.Equal(expectedScorePass, actualScorePass);
            Assert.Equal(expectedScoreFail, actualScoreFail);
        }

        [Fact]
        public void ReturnScoreForTwosToSixes()
        {
            var yatzy = new YatzyGame();
            var diceRoll1 = new int[5] {1,1,2,4,4};
            var diceRoll2 = new int[5] {2,3,2,5,1};
            var diceRoll3 = new int[5] {3,3,3,4,5};
            var category1 = "fours";
            var category2 = "twos";
            var category3 = "ones";
            var expectedScore1 = 8;
            var expectedScore2 = 4;
            var expectedScore3 = 0;

            var actualScore1 = yatzy.CalculateScore(diceRoll1, category1);
            var actualScore2 = yatzy.CalculateScore(diceRoll2, category2);
            var actualScore3 = yatzy.CalculateScore(diceRoll3, category3);

            Assert.Equal(expectedScore1, actualScore1);
            Assert.Equal(expectedScore2, actualScore2);
            Assert.Equal(expectedScore3, actualScore3);
        }

        [Fact]
        public void ReturnScoreForPair()
        {
            var yatzy = new YatzyGame();
            var diceRoll1 = new int[5] {3,3,3,4,4};
            var diceRoll2 = new int[5] {1,1,6,2,6};
            var diceRoll3 = new int[5] {3,3,3,4,1};
            var diceRoll4 = new int[5] {3,3,3,3,1};
            var category = "pair";
            var expectedScore1 = 8;
            var expectedScore2 = 12;
            var expectedScore3 = 6;
            var expectedScore4 = 6;


            var actualScore1 = yatzy.CalculateScore(diceRoll1, category);
            var actualScore2 = yatzy.CalculateScore(diceRoll2, category);
            var actualScore3 = yatzy.CalculateScore(diceRoll3, category);
            var actualScore4 = yatzy.CalculateScore(diceRoll4, category);

            Assert.Equal(expectedScore1, actualScore1);
            Assert.Equal(expectedScore2, actualScore2);
            Assert.Equal(expectedScore3, actualScore3);
            Assert.Equal(expectedScore4, actualScore4);
        }

        [Fact]
        public void ReturnScoreForTwoPairs()
        {
            var yatzy = new YatzyGame();
            var diceRoll1 = new int[5] {1,1,2,3,3};
            var diceRoll2 = new int[5] {1,1,2,3,4};
            var diceRoll3 = new int[5] {1,1,2,2,2};
            var category = "two pairs";
            var expectedScore1 = 8;
            var expectedScore2 = 0;
            var expectedScore3 = 6;

            var actualScore1 = yatzy.CalculateScore(diceRoll1, category);
            var actualScore2 = yatzy.CalculateScore(diceRoll2, category);
            var actualScore3 = yatzy.CalculateScore(diceRoll3, category);

            Assert.Equal(expectedScore1, actualScore1);
            Assert.Equal(expectedScore2, actualScore2);
            Assert.Equal(expectedScore3, actualScore3);
        }

        [Fact]
        public void ReturnScoreForThreeOfAKind()
        {
            var yatzy = new YatzyGame();
            var category = "three of a kind";
            var diceRoll1 = new int[5] {3,3,3,4,5};
            var diceRoll2 = new int[5] {3,3,4,5,6};
            var diceRoll3 = new int[5] {3,3,3,3,1};
            var expectedScore1 = 9;
            var expectedScore2 = 0;
            var expectedScore3 = 9;

            var actualScore1 = yatzy.CalculateScore(diceRoll1, category);
            var actualScore2 = yatzy.CalculateScore(diceRoll2, category);
            var actualScore3 = yatzy.CalculateScore(diceRoll3, category);

            Assert.Equal(expectedScore1, actualScore1);
            Assert.Equal(expectedScore2, actualScore2);
            Assert.Equal(expectedScore3, actualScore3);
        }

        [Fact]
        public void ReturnScoreForFourOfAKind()
        {
            var yatzy = new YatzyGame();
            var category = "four of a kind";
            var diceRoll1 = new int[5] {2,2,2,2,5};
            var expectedScore1 = 8;

            var actualScore1 = yatzy.CalculateScore(diceRoll1, category);

            Assert.Equal(expectedScore1, actualScore1);
        }

        [Fact]
        public void ReturnScoreForSmallStraight()
        {
            var yatzy = new YatzyGame();
            var category = "small straight";
            var diceRoll1 = new int[5] {1,2,3,4,5};
            var diceRoll2 = new int[5] {2,3,4,5,6};
            var expectedScore1 = 15;
            var expectedScore2 = 0;

            var actualScore1 = yatzy.CalculateScore(diceRoll1, category);
            var actualScore2 = yatzy.CalculateScore(diceRoll2, category);

            Assert.Equal(expectedScore1, actualScore1);
            Assert.Equal(expectedScore2, actualScore2);
        }

        [Fact]
        public void ReturnScoreForLargeStraight()
        {
            var yatzy = new YatzyGame();
            var category = "large straight";
            var diceRoll1 = new int[5] {1,2,3,4,5};
            var diceRoll2 = new int[5] {2,3,4,5,6};
            var expectedScore1 = 0;
            var expectedScore2 = 20;

            var actualScore1 = yatzy.CalculateScore(diceRoll1, category);
            var actualScore2 = yatzy.CalculateScore(diceRoll2, category);

            Assert.Equal(expectedScore1, actualScore1);
            Assert.Equal(expectedScore2, actualScore2);
        }

        [Fact]
        public void ReturnScoreForFullHouse()
        {
            var yatzy = new YatzyGame();
            var category = "full house";
            var diceRoll1 = new int[5] {1,1,2,2,2};
            var diceRoll2 = new int[5] {2,2,3,3,4};
            var diceRoll3 = new int[5] {4,4,4,4,4};
            var expectedScore1 = 8;
            var expectedScore2 = 0;
            var expectedScore3 = 0;

            var actualScore1 = yatzy.CalculateScore(diceRoll1, category);
            var actualScore2 = yatzy.CalculateScore(diceRoll2, category);
            var actualScore3 = yatzy.CalculateScore(diceRoll3, category);

            Assert.Equal(expectedScore1, actualScore1);
            Assert.Equal(expectedScore2, actualScore2);
            Assert.Equal(expectedScore3, actualScore3);
        }
    }
    
}
