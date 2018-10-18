using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taken5Bart.Controllers
{
    public class Team
    {
        public int Id { get; set; }
        public string TeamNaam { get; set; }
        public List<Speler> Spelers { get; set; }
        public int DiamantenVerzameld { get; set; }
        public Puzzel ActievePuzzel { get; set; }
        public List<Puzzel> PuzzelsVoltooid { get; set; }
        public List<Puzzel> PuzzelsTD { get; set; }
        public int RanglijstPos { get; set; }
    }
}
