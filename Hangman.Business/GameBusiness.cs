using Hangman.Business.Interface;
using Hangman.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Hangman.Business
{
    public class GameBusiness : IGameBusiness
    {
        private string xmlPath;
        public GameBusiness()
        {
            xmlPath = @".\Hangman.xml";
        }
        public GameBusiness(string path)
        {
            xmlPath = path;
        }
        public PlayStatus Play(PlayStatus play)
        {
            play.TriedLetters += " "+play.Shot.ToUpper();
            if (!play.Word.ToUpper().Contains(play.Shot.ToUpper()))
            {
                play.ErrorsQuantity++;
                
                if (play.ErrorsQuantity == 6)
                    play.Message = "Sorry, you lose!";
                return play;
            }
            else
            {
                play.CorrectedLetters = string.Empty;
                int correct = 0;
                foreach (var letter in play.Word.ToCharArray())
                {
                    if (play.TriedLetters.ToUpper().Contains(letter.ToString().ToUpper()))
                    {
                        correct++;
                        play.CorrectedLetters += letter;
                    }
                    else
                        play.CorrectedLetters += "X";
                }

                if (correct == play.Word.Length)
                    play.Message = "Congratulations, you won the game.";
            }
            return play;
        }

        public PlayStatus RandomWord()
        {
            XmlTextReader reader = new XmlTextReader(xmlPath);
            var list = new List<string>();
            while(reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Text)
                    list.Add(reader.Value);
            }
            var word = new PlayStatus();
            word.Word = list[new Random().Next(list.Count - 1)];
            foreach (var item in word.Word.ToCharArray())
            {
                if (item.ToString() != " ")
                    word.CorrectedLetters += "X";
                else
                    word.CorrectedLetters += " ";
            }
            return word;
        }
    }
}
