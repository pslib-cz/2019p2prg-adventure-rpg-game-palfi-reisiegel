using Adventure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adventure.Services
{
    public class EveryArea
    {
        private Dictionary<Areas, ILocation> _areas;
        private List<Paths> _paths;

        public EveryArea()
        {
            //místnosti
            _areas = new Dictionary<Areas, ILocation>();
            _paths = new List<Paths>();
            _areas.Add(Areas.Gate, new Location { Title = "Gate", Description = "In middle of nowhere you're standing in front of massive castle. The Castle has a gate made of pure iron, that is somehow opened, then you choose to proceed" });
            _areas.Add(Areas.DiningRoom, new Location { Title = "Dinning room", Description = "When you get inside of this precious castle, you see a dining room with plates filled with numerous dishes, that have you never imagined. And Throne"});
            _areas.Add(Areas.DeathRoom, new Location { Title = "Death room", Description = "Well it killed you, what a twist." });
            _areas.Add(Areas.SecondFloor, new Location { Title = "Second floor", Description = "It seems rather empty, only a room named as death room available to enter, do you want to enter?" });
            _areas.Add(Areas.DeathRoom, new Location { Title = "Death room", Description = "Well it killed you, what a twist." });

        }
    }
}
