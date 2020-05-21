using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Adventure.Models.SideGamesData;
using Microsoft.AspNetCore.Mvc;

namespace Adventure.Services.SideGamesServices
{
    public class NumberService
    {
        [BindProperty]
        public NumberData Data { get; set; } = new NumberData();
        public NumberEnum Guessing(int number, int random)
        {
            if (number < random)
            {
                return NumberEnum.IsLower;
            }
            if (number > random)
            {
                return NumberEnum.IsGreater;

            }
            if (number == random)
            {
                return NumberEnum.Success;
            }
            else
            {
                return NumberEnum.None;
            }
        }
    }
}
