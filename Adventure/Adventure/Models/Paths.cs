using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adventure.Models
{
    public class Paths
    {
        public Paths(string dascription, Areas from, Areas to)
        {
            Dascription = dascription;
            From = from;
            To = to;
        }

        public string Dascription { get; set; }
        public Areas From { get; set; }
        public Areas To { get; set; }
        public Func<PlayerStats, bool> Condition { get; set; }
    }
}
