using Hangman.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hangman.Business.Interface
{
    public interface IPlayerBusiness
    {
        ReturnOperation AddPlayer(Player player);
    }
}
