using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Adventure.Models.SideGamesData;
using Adventure.Services.SideGamesServices;
using Adventure.Models;
using Adventure.Services;

namespace Adventure.Pages
{
    public class RPSModel : PageModel
    {
        public List<Paths> Paths { get; set; }

        [BindProperty]
        public RPSData Data { get; set; } = new RPSData();
        public PlayerStats State { get; set; } = new PlayerStats();
        private GameService _gg;
        //private RPSService _sv;
        private Random _random;
        public RPSModel(RPSService sv, GameService gg)
        {
            _random = new Random();
            //_sv = sv;
            _gg = gg;
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
                
                //_gg.State.Location = Areas.RPS;
                Paths = _gg.Paths;
                Data.Computer = (RPSEnum)_random.Next(1, 4);
                if (Data.Player != Data.Computer)
                {
                    if (
                        (Data.Player == RPSEnum.Rock && Data.Computer == RPSEnum.Scissors) ||
                        (Data.Player == RPSEnum.Scissors && Data.Computer == RPSEnum.Paper) ||
                        (Data.Player == RPSEnum.Paper && Data.Computer == RPSEnum.Rock)
                       )
                    {
                        Data.Wins++;
                    }
                    else
                    {
                        Data.Lose++;
                    }
                    
                    /*
                    if (
                       (Data.Computer == RPSEnum.Rock && Data.Player == RPSEnum.Scissors) ||
                       (Data.Computer == RPSEnum.Scissors && Data.Player == RPSEnum.Paper) ||
                       (Data.Computer == RPSEnum.Paper && Data.Player == RPSEnum.Rock)
                      )
                    {


                        lose++;
                    }
                    */
                }
                //_sv.RPSGame(Data.Player, Data.Computer, Data.Wins, Data.Lose);
                if(Data.Wins == 3)
                {
                    State.Money += 20;
                    
                }
                if (Data.Lose == 3)
                {
                    State.Money -= 20;
                    
                }
                //return RedirectToPage("/Prize");
            }
            return Page();
            /*
            if (Data.Won == true)
            {
                return RedirectToPage("/Rooms?id=Betroom");
            }
            */
            
        }
    }
}