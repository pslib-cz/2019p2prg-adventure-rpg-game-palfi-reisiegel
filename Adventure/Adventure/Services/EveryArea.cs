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
            _areas.Add(Areas.Gate, new Location { Title = "Gate", Description = "In middle of nowhere you're standing in front of massive castle. The castle has a gate made of pure iron, that is somehow opened, then you choose to proceed" });
            _areas.Add(Areas.Hall, new Location { Title = "Hall", Description = "When you get inside of this precious castle, you see a dining room with plates filled with numerous dishes, that have you never imagined and of course, the throne room" });
            _areas.Add(Areas.DiningRoom, new Location { Title = "Dining room", Description = "*munch*" });
            _areas.Add(Areas.ThroneRoom, new Location { Title = "Throne room", Description = "Theres a table with chalices, which are filled with wine strangely, but that's about it." });

            _areas.Add(Areas.SecondFloor, new Location { Title = "Second floor", Description = "Many rooms to enter, but which room? Kitchen, Betroom or Deathroom." });

            _areas.Add(Areas.Floor, new Location { Title = "Just a Floor", Description = "You fall on the floor, get back up, you're not made of floor" });

            _areas.Add(Areas.Betroom, new Location { Title = "Bedroom with bets and debts", Description = "Betroom because this is where king sleeps and maked bets, obviously. Other than that, there's his crown, that he somehow forgot, even his key is here but, where it belongs? You even notice a ladder which goes to up on the roof of the tower." });
            _areas.Add(Areas.Tower, new Location { Title = "Tower", Description = "You will just die, there's no comeback, and the TV you brought is useless." });

            _areas.Add(Areas.Kitchen, new Location { Title = "Kitchen", Description = "You went into the kitchen of this castle, you think about, how do they bring their food on the table in the dining room, then you notice that they have their own elevator, which leads to first floor in dining room." });
            _areas.Add(Areas.Elevator, new Location { Title = "Elevator", Description = "You can send yout some food, or yourself" });
            _areas.Add(Areas.SendFood, new Location { Title = "Sending food", Description = "You've sent some food. You are proud of yourself." });

            _areas.Add(Areas.DeathRoom, new Location { Title = "Death room", Description = "It was painful but you live somehow. With some wound you manage to get to the door, which gives you and opportunity to escape." });
            _areas.Add(Areas.DeathRoom2, new Location { Title = "Death room", Description = "Nope the door was stuck, you were pulling this door so hard, that the old-fashioned handle was pulled of. Spike were coming your way and it hurt you." });
            _areas.Add(Areas.DeathRoom3, new Location { Title = "Death room", Description = "Your only option was break through the door. Which was succesful, maybe you're really hurt, but you got throught that, and of course, there's no turning back. Or is it?" });

            _areas.Add(Areas.AlmostEmptyRoom, new Location { Title = "Empty", Description = "This room is rather empty, pretty suspicious for a big castle. Only thing, that really catched you eye is pretty big hole in the center of the room." });
            _areas.Add(Areas.SecretChamber, new Location { Title = "??", Description = "How many rooms you needed to get here? (hint: from gate to here)" });
            _areas.Add(Areas.Cellar, new Location { Title = "Cellar", Description = "Congratulations, you're in… cellar. But dont worry, you can escape, but you hear some rattle from the cellar. You should investigate, or not. Your choice" });
            _areas.Add(Areas.Cell, new Location { Title = "Cell", Description = "You've approched a cell, what will you do?" });

            _paths.Add(new Paths("Proceed", Areas.Gate, Areas.Hall));

            _paths.Add(new Paths("Go to dining room", Areas.Hall, Areas.DiningRoom));
            _paths.Add(new Paths("Go back", Areas.DiningRoom, Areas.Hall));
            _paths.Add(new Paths("Go into the throne room", Areas.Hall, Areas.ThroneRoom));
            _paths.Add(new Paths("Go back", Areas.ThroneRoom, Areas.Hall));
            _paths.Add(new Paths("Go up to second floor", Areas.Hall, Areas.SecondFloor));


            _paths.Add(new Paths("Go back", Areas.SecondFloor, Areas.Hall));
            _paths.Add(new Paths("Go into the kitchen", Areas.SecondFloor, Areas.Kitchen));
            _paths.Add(new Paths("Go back", Areas.Kitchen, Areas.SecondFloor));
            _paths.Add(new Paths("Approach elevator", Areas.Kitchen, Areas.Elevator));
            _paths.Add(new Paths("Ride to the bottom", Areas.Elevator, Areas.DiningRoom));
            _paths.Add(new Paths("Send food", Areas.Elevator, Areas.SendFood));
            _paths.Add(new Paths("Go back", Areas.SendFood, Areas.Elevator));
            _paths.Add(new Paths("Go into the Betroom", Areas.SecondFloor, Areas.Betroom));
            _paths.Add(new Paths("Go back", Areas.Betroom, Areas.SecondFloor));


            _paths.Add(new Paths("Go into the death room", Areas.SecondFloor, Areas.DeathRoom));
            _paths.Add(new Paths("Open the door", Areas.DeathRoom, Areas.DeathRoom2));
            _paths.Add(new Paths("DOOR STUCK!", Areas.DeathRoom2, Areas.DeathRoom3));

            _paths.Add(new Paths("I don't know, but I live!", Areas.DeathRoom3, Areas.AlmostEmptyRoom));
            _paths.Add(new Paths("Fall into the hole", Areas.AlmostEmptyRoom, Areas.Cellar));
            _paths.Add(new Paths("___", Areas.AlmostEmptyRoom, Areas.SecretChamber));

            _paths.Add(new Paths("Approach cell", Areas.Cellar, Areas.Cell));
            _paths.Add(new Paths("Go throught the door", Areas.Cellar, Areas.Door));
            _paths.Add(new Paths("Go back", Areas.Cell, Areas.Cellar));

            //Your Death
            _areas.Add(Areas.TheEnd, new Location { Title = "The End", Description = "This is where it ends for you…" });
            _paths.Add(new Paths("Start again", Areas.TheEnd, Areas.Gate)); //, (h) => { if (h.HP > 0) { return false; } else { return true; } }



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
