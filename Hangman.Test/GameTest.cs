using Hangman.Business;
using Hangman.Model;
using Hangman.Model.Enum;
using System;
using Xunit;

namespace Hangman.Test
{
    public class GameTest
    {
        [Fact]
        public void ShouldGenerateRandomWord()
        {
            var word = new GameBusiness(@Environment.CurrentDirectory.Substring(0, Environment.CurrentDirectory.IndexOf("Hangman.Test")-1)+ @"\Hangman.Business\Hangman.xml").RandomWord();

            Assert.True(word != null && !string.IsNullOrEmpty(word.Word) && !string.IsNullOrEmpty(word.CorrectedLetters));
        }
        [Fact]
        public void ShouldWonTheGame()
        {
            var word = new PlayStatus()
            {
                CorrectedLetters = "XXXX",
                Word = "TEST",
                ErrorsQuantity = 0
            };

            foreach (var item in new String("Test").ToCharArray())
            {
                word.Shot = item.ToString();
                word = new GameBusiness(Environment.CurrentDirectory).Play(word);
            }

            Assert.True(word.ErrorsQuantity == 0 && word.Message == "Congratulations, you won the game.");
            
        }
        [Fact]
        public void ShouldLoseTheGame()
        {
            var word = new PlayStatus()
            {
                CorrectedLetters = "XXXX",
                Word = "TEST",
                ErrorsQuantity = 0
            };

            foreach (var item in new String("ABCDEFG").ToCharArray())
            {
                word.Shot = item.ToString();
                word = new GameBusiness(Environment.CurrentDirectory).Play(word);
            }

            Assert.True(word.ErrorsQuantity == 6 && word.Message == "Sorry, you lose!");

        }
    }
}
