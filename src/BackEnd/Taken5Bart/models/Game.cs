using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Game
    {
        public int Id { get; set; }
        public String Stad { get; set; }
        public ICollection<Sessie> Sessie { get; set; }
        public ICollection<Puzzel> MogelijkePuzzels { get; set; }
    }
}
