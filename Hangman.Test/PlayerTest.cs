using Hangman.Business;
using Hangman.Model;
using Hangman.Model.Enum;
using System;
using Xunit;

namespace Hangman.Test
{
    public class PlayerTest
    {
        [Fact]
        public void ShouldInsertValidPlayer()
        {
            var player = new Player();
            player.Name = "Ricardo";
            player.Email = "rlaskoski86@gmail.com";

            var result = new PlayerBusiness().AddPlayer(player);
            Assert.True(result.ReturnType == ReturnType.OK);
        }

        [Fact]
        public void ShouldInsertValidPlayerName()
        {
            var player = new Player();
            player.Email = "rlaskoski86@gmail.com";

            var result = new PlayerBusiness().AddPlayer(player);
            Assert.True(result.ReturnType == ReturnType.Error && result.Message == "Player's name must be informed.");
        }
        [Fact]
        public void ShouldInsertValidPlayerEmail()
        {
            var player = new Player();
            player.Name = "Ricardo";

            var result = new PlayerBusiness().AddPlayer(player);
            Assert.True(result.ReturnType == ReturnType.Error && result.Message == "Player's e-mail must be informed.");
        }
    }
}
