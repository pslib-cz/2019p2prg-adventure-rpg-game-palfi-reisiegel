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
    public class StartModel : PageModel
    {
        private GameService _sv;
        public PlayerStats Player { get; set; }
        public Location Location { get; set; }

        public List<Paths> Paths { get; set; }
        public StartModel(GameService sv)
        {
            _sv = sv;
        }

        public void OnGet()
        {
            _sv.Start();
            Paths = _sv.Paths;
            Location = _sv.Location;
            
        }
        
    }
}