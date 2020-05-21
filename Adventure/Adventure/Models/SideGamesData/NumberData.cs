using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Adventure.Models.SideGamesData
{
    public class NumberData
    {
        [Required]
        [BindProperty]
        public int PlayerNumber { get; set; }
        [BindProperty]
        public int RandComputerNumber { get; set; }

        public string Message { get; set; }
        public int Guesses { get; set; }
        public NumberEnum Result { get; set; } = 0;

    }
}
