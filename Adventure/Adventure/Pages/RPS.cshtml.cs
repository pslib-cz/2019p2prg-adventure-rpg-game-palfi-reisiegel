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
        private RPSService _sv;
        public RPSModel(RPSService sv)
        {
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
                _sv.RPSGame(Data.Player, Data.Computer);
            }
            if (Data.Won == true)
            {
                return RedirectToPage("/Rooms?id=Betroom");
            }
            return Page();
        }
    }
}