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
            _areas.Add(Areas.Gate, new Location { Title = "Gate", Description = "In middle of nowhere you're standing in front of massive castle. <p>The castle has a gate made of pure iron, that is somehow opened, then you choose to proceed." });
            _areas.Add(Areas.Hall, new Location { Title = "Hall", Description = "When you get inside of this precious castle, you see a dining room with plates filled with numerous dishes, that you have never imagined. <p>And like in every castle, there's a throne room." });
            _areas.Add(Areas.DiningRoom, new Location { Title = "Dining room", Description = "You ate some of the precious meal.<p>Really tasty." });
            _areas.Add(Areas.ThroneRoom, new Location { Title = "Throne room", Description = "There's a table with chalices, which are filled with wine, which is pretty strange, but that's about it." });
            //Second floor
            _areas.Add(Areas.SecondFloor, new Location { Title = "Second floor", Description = "Many rooms to enter, but which one? <p>A kitchen, a bedroom or a deathroom?" });
            //just a Floor
            _areas.Add(Areas.Floor, new Location { Title = "Just a Floor", Description = "You fell on the floor, get back up, you're not made out of the floor." });
            //bedroom
            _areas.Add(Areas.Betroom, new Location { Title = "Bedroom", Description = "You entered the bedroom, where's the king probably sleeps, because there's his crown, which should be by his side, even his key is here. <p>You noticed a ladder which goes up on the roof of the tower." });
            _areas.Add(Areas.BedTime, new Location { Title = "Sleeping", Description = "You went to sleep. It was a really comfortable bed, but you feel also guilty, because you slept in someone else's bed." });
            _areas.Add(Areas.Tower, new Location { Title = "Tower", Description = "You will just die, there's no comeback, and the TV you brought is useless." });
            //Kitchen
            _areas.Add(Areas.Kitchen, new Location { Title = "Kitchen", Description = "You went into the kitchen, you think about: <p>'How do they bring their food on the table into the dining room?'</p> <p>Then you notice that they have their own elevator, which leads to first floor where's the dining room." });
            _areas.Add(Areas.Elevator, new Location { Title = "Elevator", Description = "You are in front of the elevator.<p>You can send some food, or yourself" });
            _areas.Add(Areas.SendFood, new Location { Title = "Sending food", Description = "You've sent some food. You're proud of yourself." });

            //death room
            _areas.Add(Areas.DeathRoom, new Location { Title = "Death room", Description = "It was painful but you're somehow alive. <p>With some wounds you manage to get to the doors, which gives you and opportunity to escape." });
            _areas.Add(Areas.DeathRoom2, new Location { Title = "Death room", Description = "Nope. <p>These doors are stuck, you were pulling them so hard, that the old-fashioned handles were pulled off.</p> <p>Spikes were coming to your way and they hurt you." });
            _areas.Add(Areas.DeathRoom3, new Location { Title = "Death room", Description = "Your only option is to break through the doors. Which was succesful. <p>Maybe you're really hurt, but you've got through that. There's no turning back. Or is it?" });
            //cela a secret chamber
            _areas.Add(Areas.AlmostEmptyRoom, new Location { Title = "Empty", Description = "This room is rather empty, pretty suspicious for a big castle. <p>Only thing, that really catches your eye is a pretty big hole in the center of the room." });
            _areas.Add(Areas.Falling, new Location { Title = "Falling", Description = "You're falling through the hole really quickly, which suddenly changed into huge impact on the ground" });
            _areas.Add(Areas.Cellar, new Location { Title = "Cellar", Description = "Congratulations, you're in… cellar. But don't worry, you can escape. <p>You hear some rattling from the nearby cell. You should investigate, or not. It's your choice." });
            _areas.Add(Areas.Cell, new Location { Title = "Cell", Description = "You've approched a cell, what will you do?" });
            _areas.Add(Areas.Skeleton, new Location { Title = "Skeldo", Description = "Ahhh how are ya doin' matey! Where're ya portin' stranger?" });
            _areas.Add(Areas.Skeleton1, new Location { Title = "Skeldo", Description = "Who am I? I should say who are YOU? I'm just a local skeleton who likes to help!" });

            _areas.Add(Areas.Door, new Location { Title = "Door", Description = "You've opened the door and realised, it goes back to the hall!" });
            _areas.Add(Areas.SecretChamber, new Location { Title = "??", Description = "How many rooms did you need to get here?<p>Hint: From gate to here." });
            _areas.Add(Areas.FalseAnswer, new Location { Title = "You Failed", Description = "That was a wrong answer." });

            _areas.Add(Areas.SecretChamber2, new Location { Title = "Secret Chamber", Description = "Tadadada! You've found a Secret Chamber! <p>But the doors closed so you have to move forward…" });
            _areas.Add(Areas.SecretChamber3, new Location { Title = "Secret Chamber", Description = "When you get to the end of the corridor of this chamber, you see a man, who has a really nice robe and he's decorated with jewelry, such as bracelets, rings, shiny necklace and even earrings. <p>It was a king himself, but without the actual crown.</p> <p> He noticed you and started to speak to you." });
            _areas.Add(Areas.King, new Location { Title = "King", Description = "Welcome to this magnificent chamber, which was built when the castle was still under construction, which no one knew about it, only the very people who built it.<p>The rumors says that the secret chamber doesn't exist, but as you can see the opposite is the truth. That what lies before you is a magical item, which a mere human cannot access.</p> <p>There's a one way how to get to it. You need to guess his number, which will turn off the security system.</p> <p>Please play the so-called 'game' with me." });
            _areas.Add(Areas.TheNormalEnd, new Location { Title = "You Won?", Description = "You refused, because you didn't want to get into even bigger trouble than you are. <p>King understands.</p> <p>He showed you a secret way, how to get out of the castle. Then you left and no one has ever seen you again." });

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
            _paths.Add(new Paths("Go into the bedroom", Areas.SecondFloor, Areas.Betroom));
            _paths.Add(new Paths("Go back", Areas.Betroom, Areas.SecondFloor));
            _paths.Add(new Paths("Go back",Areas.BedTime, Areas.Betroom));
            _paths.Add(new Paths("Go to sleep", Areas.Betroom, Areas.BedTime));

            _paths.Add(new Paths("Climb the ladder", Areas.Betroom, Areas.Tower));
            _paths.Add(new Paths("Die", Areas.Tower, Areas.TheEnd));

            _paths.Add(new Paths("Go into the death room", Areas.SecondFloor, Areas.DeathRoom));
            _paths.Add(new Paths("Open the door", Areas.DeathRoom, Areas.DeathRoom2));
            _paths.Add(new Paths("DOOR STUCK!", Areas.DeathRoom2, Areas.DeathRoom3));

            _paths.Add(new Paths("I don't know, but I'm alive!", Areas.DeathRoom3, Areas.AlmostEmptyRoom));
            _paths.Add(new Paths("Fall into the hole", Areas.AlmostEmptyRoom, Areas.Falling));
            _paths.Add(new Paths("Ouch!", Areas.Falling, Areas.Cellar));

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
            _paths.Add(new Paths("Go through the door", Areas.Cellar, Areas.Door));
            _paths.Add(new Paths("Continue", Areas.Door, Areas.Hall));
            _paths.Add(new Paths("Go back", Areas.Cell, Areas.Cellar));
            _paths.Add(new Paths("Knock on the cell", Areas.Cell, Areas.Skeleton));

            _paths.Add(new Paths("Go back", Areas.Skeleton, Areas.Cellar));
            _paths.Add(new Paths("Go back", Areas.Skeleton1, Areas.Skeleton));
            _paths.Add(new Paths("Who are you?", Areas.Skeleton, Areas.Skeleton1));
            _paths.Add(new Paths("Teleport to second floor", Areas.Skeleton, Areas.SecondFloor));
            _paths.Add(new Paths("Teleport to empty room", Areas.Skeleton, Areas.AlmostEmptyRoom));
            _paths.Add(new Paths("Teleport to kitchen", Areas.Skeleton, Areas.Kitchen));

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
