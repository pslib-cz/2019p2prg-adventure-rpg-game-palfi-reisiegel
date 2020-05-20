using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adventure.Models
{
    public class PlayerStats
    {
        public int Money { get; set; }
        public int HP { get; set; }
        public int MP { get; set; }
        public Areas Location { get; set; }
    }
}
