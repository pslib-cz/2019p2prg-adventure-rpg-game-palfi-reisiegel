using Adventure.Models.SideGamesData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adventure.Services.SideGamesServices
{
    public class RPSService
    {
        
        
        public void RPSGame(RPSEnum player, RPSEnum computer, int wins, int lose)
        { 
            if (player != computer)
            {
                if (
                    (player == RPSEnum.Rock && computer == RPSEnum.Scissors) ||
                    (player == RPSEnum.Scissors && computer == RPSEnum.Paper) ||
                    (player == RPSEnum.Paper && computer == RPSEnum.Rock)
                   )
                {
                    wins++;//it doesn't work why?
                }

                if (
                   (computer == RPSEnum.Rock && player == RPSEnum.Scissors) ||
                   (computer == RPSEnum.Scissors && player == RPSEnum.Paper) ||
                   (computer == RPSEnum.Paper && player == RPSEnum.Rock)
                  )
                {

                    
                    lose++;
                }
            }
            if (wins == 3)
            {
                //won = true;
            }
            if(lose == 3)
            {
                //won = false;
                //Where is mistake?       
            }
        }
    }
}
