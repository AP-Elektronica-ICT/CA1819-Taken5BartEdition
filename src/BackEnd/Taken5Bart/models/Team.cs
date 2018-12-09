using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models.T5B
{
    public class Team
    {
        public int Id { get; set; }
        public string TeamNaam { get; set; }
        public ICollection<Speler> Spelers { get; set; }
        public int DiamantenVerzameld { get; set; }
        public int ActivePuzzel { get; set; } //deze bevat de puzzelid van de actieve puzzel, -1 indien dat de spelers niet bezig zijn met een puzzel
                                              //public ICollection<Int32> Puzzellijst { get; set; } //op volgorde dat gedaan moet worden
        [JsonIgnore]
        public ICollection<PuzzelTeam> PuzzelsTeam { get; } = new List<PuzzelTeam>();

        public int Score { get; set; }

        [JsonIgnore]
        public Sessie AssignedSessie { get; set; }
    }
}
