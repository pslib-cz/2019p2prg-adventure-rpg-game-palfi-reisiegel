using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adventure.Models
{
    public class Paths
    {
        public Paths(string description, Areas from, Areas to, Func<PlayerStats, bool> condition = null)
        {
            Description = description;
            From = from;
            To = to;
        }

        public string Description { get; set; }
        public Areas From { get; set; }
        public Areas To { get; set; }
        public Func<PlayerStats, bool> Condition { get; set; }
    }
}
