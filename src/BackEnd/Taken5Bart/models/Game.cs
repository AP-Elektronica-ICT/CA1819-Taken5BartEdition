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
        public List<Sessie> Sessie { get; set; }
        public List<Puzzel> MogelijkePuzzels { get; set; }
    }
}
