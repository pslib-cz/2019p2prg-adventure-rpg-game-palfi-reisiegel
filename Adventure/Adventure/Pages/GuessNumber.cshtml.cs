using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Adventure.Models.SideGamesData;
using Adventure.Services.SideGamesServices;
using Adventure.Models;

namespace Adventure.Pages
{
    public class GuessNumberModel : PageModel
    {
        private NumberService _sv;
        private Random _random;

        [BindProperty]
        public NumberData Property { get; set; } = new NumberData();

        public GuessNumberModel(NumberService sv)
        {
            _sv = sv;
            _random = new Random();
        }
        public void OnGet()
        {
            Property.RandComputerNumber = _random.Next(1, 100);
            Property.Message = "Vítejte ve hře hádání čísla. Prosím zadejte číslo";


        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                Property.Result = _sv.Guessing(Property.PlayerNumber, Property.RandComputerNumber);
                Property.Guesses++;
            }
            if (Property.PlayerNumber == Property.RandComputerNumber)
            {
                return RedirectToPage("/Wins");
            }
            return Page();


        }
    }
}