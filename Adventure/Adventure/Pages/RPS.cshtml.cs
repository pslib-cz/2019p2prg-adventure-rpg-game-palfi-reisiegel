using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Adventure.Models.SideGamesData;
using Adventure.Services.SideGamesServices;

namespace Adventure.Pages
{
    public class RPSModel : PageModel
    {
        [BindProperty]
        public RPSData Data { get; set; } = new RPSData();
        public RPSService serv { get; set; }

        private RPSService _sv;
        private Random _random;
        public RPSModel(RPSService sv)
        {
            _random = new Random();
            _sv = sv;
        }
        public void OnGet()
        {
            Data.Player = RPSEnum.None;
            Data.Computer = RPSEnum.None;
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                Data.Computer = (RPSEnum)_random.Next(1, 4);
                //napiš Data.něco = *zbytek*
                _sv.RPSGame(Data.Player, Data.Computer, Data.Wins++, Data.Lose++);
                
            }
            if (Data.Won == true)
            {
                return RedirectToPage("/Rooms?id=Betroom");
            }
            return Page();
        }
    }
}