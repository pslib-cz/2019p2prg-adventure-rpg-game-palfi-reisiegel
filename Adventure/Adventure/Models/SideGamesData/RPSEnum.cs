using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Adventure.Models.SideGamesData
{
    public enum RPSEnum
    {
        [Display(Name = "Bez volby")]
        None,
        [Display(Name = "Kámen")]
        Rock,
        [Display(Name = "Papír")]
        Paper,
        [Display(Name = "Nůžky")]
        Scissors
    }
}
