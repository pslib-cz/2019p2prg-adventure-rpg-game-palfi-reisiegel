using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adventure.Services
{
    public interface ISessionStorage<T>
    {
        public T LoadOrCreate{ get; set; }
        public void Save{ get; set; }
    }
}
