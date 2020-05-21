using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Adventure.Models.SideGamesData
{ 
    public enum NumberEnum
    {
        None,
        [Display(Name = "is greater!")]
        IsGreater,
        [Display(Name = "is lower!")]
        IsLower,
        Success
    }
}
