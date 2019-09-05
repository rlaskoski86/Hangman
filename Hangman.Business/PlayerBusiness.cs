using System;
using Hangman.Business.Interface;
using Hangman.Model;

namespace Hangman.Business
{
    public class PlayerBusiness : IPlayerBusiness
    {
        public ReturnOperation AddPlayer(Player player)
        {
            try
            {
                if (string.IsNullOrEmpty(player.Name))
                    throw new Exception("Player's name must be informed.");

                if(string.IsNullOrEmpty(player.Email))
                    throw new Exception("Player's e-mail must be informed.");

                return new ReturnOperation()
                {
                    Message = "Player informed sucessfully.",
                    ReturnType = Model.Enum.ReturnType.OK
                };
            }
            catch (Exception ex)
            {

                return new ReturnOperation() { Message = ex.Message, ReturnType = Model.Enum.ReturnType.Error };
            }
        }
    }
}
