using Adventure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adventure.Services
{
    public class GameService
    {
        private readonly ISessionStorage<PlayerStats> _sv;
        private readonly IEveryArea _ea;
        private const string KEY = "SECRETCASTLEADVENTURE";
        private const Areas START_GATE = Areas.Gate;
        private const Areas YOUR_END = Areas.TheEnd;
        public PlayerStats State { get; private set; }
        public Location Location { get { return _ea.GetLocation(State.Location); } }
        public List<Paths> Paths { get { return _ea.GetPathsFrom(State.Location); } }

        public GameService(ISessionStorage<PlayerStats> sv, IEveryArea ea)
        {
            _sv = sv;
            _ea = ea;
            State = new PlayerStats();
        }
        public void Start()
        {
            State = new PlayerStats { HP = 100, MP = 100, Money = 50, Location = START_GATE };

        }
        public void DamageAreas()
        {
            
         
            _sv.Save(KEY, State);


        }
        public void FetchData()
        {
            State = _sv.LoadOrCreate(KEY);
        }
        public void Store()
        {
            if (State.Location == Areas.DeathRoom || State.Location == Areas.DeathRoom2 || State.Location == Areas.DeathRoom3)
            {
                State.HP -= 20;
                
            }
            if (State.Location == Areas.Cellar)
            {
                State.HP -= 30;
            }
            if (State.Location == Areas.DiningRoom)
            {
                State.HP += 10;
            }
            if(State.Location == Areas.TheEnd)
            {
                State.Location = YOUR_END;
                State.HP = 0;
            }
            if(State.Location == Areas.FalseAnswer)
            {
                State.HP -= 5;
                State.MP -= 20;
                State.Money -= 5;
            }
            if (State.Location == Areas.BedTime)
            {
                State.MP += 10;
            }
            if(State.MP <= 0)
            {
                State.Location = Areas.Exhaustion;
            }
            if (State.Money <= 0)
            {
                State.Location = Areas.Poor;
            }
            if(State.HP <= 0)
            {
                State.Location = YOUR_END;
                State.HP = 0;
            }
            
            _sv.Save(KEY, State);
            

        }








    }
}
