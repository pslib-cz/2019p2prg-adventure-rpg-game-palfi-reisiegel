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
using Microsoft.Extensions.Logging;

namespace Adventure.Pages
{
    public class RPSModel : PageModel
    {
        private readonly ILogger<RPSModel> _logger;
        public List<Paths> Paths { get; set; }

        [BindProperty]
        public RPSData Data { get; set; } = new RPSData();
        public PlayerStats State { get; set; } = new PlayerStats();
        //private RPSService _sv;
        private Random _random;
        public RPSModel(ILogger<RPSModel> logger)
        {
            _logger = logger;
            _random = new Random();
        }
        public void OnGet()
        {
            Data.Player = RPSEnum.None;
            Data.Computer = RPSEnum.None;
        }
        public void OnPost()
        {
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
                    if (Data.Wins == 3)
                    {
                        Data.Won = true;
                    }
                }
                else Data.Lose++;
            }
            if (Data.Won == true)
            {
                State.Money += 20;

            }
        }
    }
}