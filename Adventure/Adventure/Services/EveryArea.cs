using Adventure.Models;
using Adventure.Models.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adventure.Services
{
    public class EveryArea : IEveryArea
    {
        private Dictionary<Areas, ILocation> _areas;
        private List<Paths> _paths;

        public EveryArea()
        {
            //místnosti
            _areas = new Dictionary<Areas, ILocation>();
            _paths = new List<Paths>();
            _areas.Add(Areas.Gate, new Location { Title = "Gate", Description = "In middle of nowhere you're standing in front of massive castle. The Castle has a gate made of pure iron, that is somehow opened, then you choose to proceed" });
            _areas.Add(Areas.Hall, new Location { Title = "Hall", Description = "When you get inside of this precious castle, you see a dining room with plates filled with numerous dishes, that have you never imagined and Throne room"});
            _areas.Add(Areas.DiningRoom, new Location { Title = "Dining room", Description = "*munch*" });
            _areas.Add(Areas.ThroneRoom, new Location { Title = "Throne room", Description = "Theres a table with chalices, which are filled with wine strangely, but that's about it" });
            _areas.Add(Areas.SecondFloor, new Location { Title = "Second floor", Description = "It seems rather empty, only a room named as death room available to enter, do you want to enter?" });
            _areas.Add(Areas.DeathRoom, new Location { Title = "Death room", Description = "Well it killed you, what a twist." });

            _paths.Add(new Paths("Proceed",Areas.Gate, Areas.Hall));
            _paths.Add(new Paths("Go to dining room", Areas.Hall, Areas.DiningRoom));
            _paths.Add(new Paths("Go back", Areas.DiningRoom, Areas.Hall));
            _paths.Add(new Paths("Go to throne room", Areas.Hall, Areas.ThroneRoom));
            _paths.Add(new Paths("Go back", Areas.ThroneRoom, Areas.Hall));
            _paths.Add(new Paths("Go to second floor", Areas.Hall, Areas.SecondFloor));
            _paths.Add(new Paths("Go back", Areas.SecondFloor, Areas.Hall));
            _paths.Add(new Paths("Go to dining room", Areas.SecondFloor, Areas.DeathRoom));

           

        }
        public bool ExistsLocation(Areas id)
        {
            return _areas.ContainsKey(id);
        }
        public List<Paths> GetPathsFrom(Areas id)
        {
            if (ExistsLocation(id))
            {
                return _paths.Where(m => m.From == id).ToList();
            }
            throw new LocationExceptions();
        }
        public List<Paths> GetPathsTo(Areas id)
        {
            throw new NotImplementedException();
        }
        public Location GetLocation(Areas id)
        {
            if (ExistsLocation(id))
            {
                return (Location)_areas[id];
            }
            throw new LocationExceptions();
        }
        public bool Navigation(Areas from, Areas to, PlayerStats state)
        {
            throw new NotImplementedException();
        }
    }
}
