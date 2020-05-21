using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adventure.Models.SideGamesData
{
    public class RPSData
    {
        public int Wins { get; set; }
        public int Lose { get; set; }
        public RPSEnum Player { get; set; }
        public RPSEnum Computer { get; set; }
        public bool Won { get; set; }
    }
}
