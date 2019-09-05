using Hangman.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hangman.Web.Models
{
    public class UserViewModel
    {
        [Required]
        public string User { get; set; }

        public Player ToPlayer()
        {
            return new Player()
            {
                Name = User
            };
        }
    }
}
