using Adventure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adventure.Services
{
    public interface IEveryArea
    {
        bool ExistsLocation(Areas id);
        Location GetLocation(Areas id);
        List<Paths> GetPathsFrom(Areas id);
        List<Paths> GetPathsTo(Areas id);
        bool Navigation(Areas from, Areas to, PlayerStats state);
    }
}
