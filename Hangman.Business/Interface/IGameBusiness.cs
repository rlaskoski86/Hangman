using Hangman.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hangman.Business.Interface
{
    public interface IGameBusiness
    {
        PlayStatus Play(PlayStatus play);
        PlayStatus RandomWord();
    }
}
