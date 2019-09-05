using System;
using System.Collections.Generic;
using System.Text;

namespace Hangman.Model
{
    public class PlayStatus
    {
        public string Word { get; set; }
        public string Shot { get; set; }
        public string CorrectedLetters { get; set; }
        public int ErrorsQuantity { get; set; }
        public string TriedLetters { get; set; }
        public string Message { get; set; }
    }
}
