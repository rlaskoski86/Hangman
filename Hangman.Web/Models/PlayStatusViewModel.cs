using Hangman.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hangman.Web.Models
{
    public class PlayStatusViewModel
    {
        public string Word { get; set; }
        public string Shot { get; set; }
        public string CorrectedLetters { get; set; }
        public int ErrorsQuantity { get; set; }
        public string TriedLetters { get; set; }

        public PlayStatus ToModel()
        {
            return new PlayStatus()
            {
                CorrectedLetters = this.CorrectedLetters,
                TriedLetters = this.TriedLetters,
                ErrorsQuantity = this.ErrorsQuantity,
                Shot = this.Shot,
                Word = this.Word
            };
        }
    }
}
