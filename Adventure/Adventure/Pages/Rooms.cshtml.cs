using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Adventure.Models;
using Adventure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Adventure.Pages
{
    public class RoomsModel : PageModel
    {
        private GameService _sv;
        public PlayerStats Player { get; set; }
        public Location Location { get; set; }
        
        public List<Paths> Paths { get; set; }
        public RoomsModel(GameService sv)
        {
            _sv = sv;
        }

        public void OnGet(Areas id)
        {
            _sv.FetchData();
            _sv.State.Location = id;

            _sv.Store();
            Location = _sv.Location;
            Paths = _sv.Paths;
            Player = _sv.State;
            _sv.DamageAreas();
            
            
        }
      
    }
}