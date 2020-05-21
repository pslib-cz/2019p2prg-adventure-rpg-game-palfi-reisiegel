using Adventure.Models.SideGamesData;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adventure.Services.SideGamesServices
{
    public class RPSService
    {
        [BindProperty]
        public RPSData Data { get; set; } = new RPSData();
        private Random _random;
        public RPSService()
        {
            _random = new Random();
        }
        public void RPSGame(RPSEnum player, RPSEnum computer)
        {
            computer = (RPSEnum)_random.Next(1, 4);
            if (player != computer)
            {
                if (
                    (player == RPSEnum.Rock && computer == RPSEnum.Scissors) ||
                    (player == RPSEnum.Scissors && computer == RPSEnum.Paper) ||
                    (player == RPSEnum.Paper && computer == RPSEnum.Rock)
                   )
                {
                    Data.Wins++;
                }
                else
                {
                    Data.Lose++;
                }
            }
            if (Data.Wins == 3)
            {
                Data.Won = true;
            }
            if(Data.Lose == 3)
            {
                Data.Won = false;
            }
        }
    }
}
