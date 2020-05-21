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
            //Start
            _areas.Add(Areas.Gate, new Location { Title = "Gate", Description = "In middle of nowhere you're standing in front of massive castle. The castle has a gate made of pure iron, that is somehow opened, then you choose to proceed" });
            _areas.Add(Areas.Hall, new Location { Title = "Hall", Description = "When you get inside of this precious castle, you see a dining room with plates filled with numerous dishes, that have you never imagined and of course, the throne room" });
            _areas.Add(Areas.DiningRoom, new Location { Title = "Dining room", Description = "*munch*" });
            _areas.Add(Areas.ThroneRoom, new Location { Title = "Throne room", Description = "Theres a table with chalices, which are filled with wine strangely, but that's about it." });
            //Second floor
            _areas.Add(Areas.SecondFloor, new Location { Title = "Second floor", Description = "Many rooms to enter, but which room? Kitchen, Betroom or Deathroom." });
            //just a Floor
            _areas.Add(Areas.Floor, new Location { Title = "Just a Floor", Description = "You fall on the floor, get back up, you're not made out of floor." });
            //bedroom
            _areas.Add(Areas.Betroom, new Location { Title = "Bedroom with bets and debts", Description = "Betroom because this is where king sleeps and maked bets, obviously. Other than that, there's his crown, that he somehow forgot, even his key is here. You even notice a ladder which goes to up on the roof of the tower." });
            _areas.Add(Areas.BedTime, new Location { Title = "Sleeping", Description = "You went to sleep. It was a really comfortable bed, but you feel guilty, that you slept in someone else's bed." });
            _areas.Add(Areas.Tower, new Location { Title = "Tower", Description = "You will just die, there's no comeback, and the TV you brought is useless." });
            

            //Kitchen
            _areas.Add(Areas.Kitchen, new Location { Title = "Kitchen", Description = "You went into the kitchen of this castle, you think about, how do they bring their food on the table in the dining room, then you notice that they have their own elevator, which leads to first floor in dining room." });
            _areas.Add(Areas.Elevator, new Location { Title = "Elevator", Description = "You can send yout some food, or yourself" });
            _areas.Add(Areas.SendFood, new Location { Title = "Sending food", Description = "You've sent some food. You are proud of yourself." });

            //death room
            _areas.Add(Areas.DeathRoom, new Location { Title = "Death room", Description = "It was painful but you somehow live. With some wound you manage to get to the door, which gives you and opportunity to escape." });
            _areas.Add(Areas.DeathRoom2, new Location { Title = "Death room", Description = "Nope the door was stuck, you were pulling this door so hard, that the old-fashioned handle was pulled of. Spike were coming your way and it hurt you." });
            _areas.Add(Areas.DeathRoom3, new Location { Title = "Death room", Description = "Your only option was break through the door. Which was succesful, maybe you're really hurt, but you got throught that, and of course, there's no turning back. Or is it?" });
            //cela a secret chamber
            _areas.Add(Areas.AlmostEmptyRoom, new Location { Title = "Empty", Description = "This room is rather empty, pretty suspicious for a big castle. Only thing, that really catched you eye is pretty big hole in the center of the room." });
            _areas.Add(Areas.Cellar, new Location { Title = "Cellar", Description = "Congratulations, you're in… cellar. But dont worry, you can escape, but you hear some rattle from the cellar. You should investigate, or not. Your choice" });
            _areas.Add(Areas.Cell, new Location { Title = "Cell", Description = "You've approched a cell, what will you do?" });
            _areas.Add(Areas.Skeleton, new Location { Title = "Skeldo", Description = "Ahhh how are ya doin' matey! Where ya portin' stranger?" });
            _areas.Add(Areas.Skeleton1, new Location { Title = "Skeldo", Description = "Who am I? I should say who are YOU? I'm just a local skeleton who likes to help!" });

            _areas.Add(Areas.Door, new Location { Title = "Door", Description = "You've opened the door and realised, it goes back to the hall!" });
            _areas.Add(Areas.SecretChamber, new Location { Title = "??", Description = "How many rooms you needed to get here? (hint: from gate to here)" });
            _areas.Add(Areas.FalseAnswer, new Location { Title = "You Failed", Description = "That was a wrong answer." });

            _areas.Add(Areas.SecretChamber2, new Location { Title = "Secret Chamber", Description = "Tadadada! You have found a Secret Chamber! But the doors closed so… you have to move forward…" });
            _areas.Add(Areas.SecretChamber3, new Location { Title = "Secret Chamber", Description = "When you're going through the Chamber, you see a man, who has a really nice robe and decorated with jewelry, such as bracelets, rings, shiny necklace and even earrings. It was a king himself, but without a crown. He noticed you and started to speak to you." });
            _areas.Add(Areas.King, new Location { Title = "King", Description = "Welcome to this magnificent chamber, which was bult when the castle was still under construction, which no one knew about it, only the very people who bult it. The rumors said, the chamber doesn't exist, but as you can see the opposite is true. That what lies before you is a magical item, which a mere human cannot access, there's a one way how to get to it. To get it, you need to guess his number, which will turn off the security system. Please play the so called 'game' with me." });
            _areas.Add(Areas.TheNormalEnd, new Location { Title = "Wins?", Description = "You left, you had enough of this. Why? I don't know it was you decision to go back and left a castle. What's the reason? Your reason, which I don't know…" });

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
            _paths.Add(new Paths("Go back",Areas.BedTime, Areas.Betroom));
            _paths.Add(new Paths("Go to sleep", Areas.Betroom, Areas.BedTime));

            _paths.Add(new Paths("Climb the ladder", Areas.Betroom, Areas.Tower));
            _paths.Add(new Paths("Die", Areas.Tower, Areas.TheEnd));

            _paths.Add(new Paths("Go into the death room", Areas.SecondFloor, Areas.DeathRoom));
            _paths.Add(new Paths("Open the door", Areas.DeathRoom, Areas.DeathRoom2));
            _paths.Add(new Paths("DOOR STUCK!", Areas.DeathRoom2, Areas.DeathRoom3));

            _paths.Add(new Paths("I don't know, but I'm alive!", Areas.DeathRoom3, Areas.AlmostEmptyRoom));
            _paths.Add(new Paths("Fall into the hole", Areas.AlmostEmptyRoom, Areas.Cellar));
            
            _paths.Add(new Paths("___", Areas.AlmostEmptyRoom, Areas.SecretChamber));


            _paths.Add(new Paths("2", Areas.SecretChamber, Areas.FalseAnswer));
            _paths.Add(new Paths("4", Areas.SecretChamber, Areas.SecretChamber2));
            _paths.Add(new Paths("10", Areas.SecretChamber, Areas.FalseAnswer));
            _paths.Add(new Paths("6", Areas.SecretChamber, Areas.FalseAnswer));
            _paths.Add(new Paths("7", Areas.SecretChamber, Areas.FalseAnswer));

            //When you fail puzzle
            _paths.Add(new Paths("Continue", Areas.FalseAnswer, Areas.SecretChamber));

            _paths.Add(new Paths("Continue", Areas.SecretChamber2, Areas.SecretChamber3));
            _paths.Add(new Paths("Talk", Areas.SecretChamber3, Areas.King));
            _paths.Add(new Paths("Refuse", Areas.King, Areas.TheNormalEnd));
            _paths.Add(new Paths("Start again…", Areas.TheNormalEnd, Areas.Gate));

            _paths.Add(new Paths("Approach cell", Areas.Cellar, Areas.Cell));
            _paths.Add(new Paths("Go throught the door", Areas.Cellar, Areas.Door));
            _paths.Add(new Paths("Continue", Areas.Door, Areas.Hall));
            _paths.Add(new Paths("Go back", Areas.Cell, Areas.Cellar));
            _paths.Add(new Paths("Knock on the cell", Areas.Cell, Areas.Skeleton));

            _paths.Add(new Paths("Go back", Areas.Skeleton, Areas.Cellar));
            _paths.Add(new Paths("Go back", Areas.Skeleton1, Areas.Skeleton));
            _paths.Add(new Paths("Who are you?", Areas.Skeleton, Areas.Skeleton1));
            _paths.Add(new Paths("Port to Second floor", Areas.Skeleton, Areas.SecondFloor));
            _paths.Add(new Paths("Port to Empty room", Areas.Skeleton, Areas.AlmostEmptyRoom));
            _paths.Add(new Paths("Port to Kitchen", Areas.Skeleton, Areas.Kitchen));

            //Your Death
            _areas.Add(Areas.TheEnd, new Location { Title = "The End", Description = "This is where it ends for you…" });
            _paths.Add(new Paths("Start again", Areas.TheEnd, Areas.Gate));
            //Exhaustion
            _areas.Add(Areas.Exhaustion, new Location { Title = "The End", Description = "You died of exhaustion" });
            _paths.Add(new Paths("Start again", Areas.Exhaustion, Areas.Gate));
            //Poor
            _areas.Add(Areas.Poor, new Location { Title = "The End", Description = "You don't have any money. You're literally broke. You can't buy anything." });
            _paths.Add(new Paths("Start again", Areas.Poor, Areas.Gate));

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
