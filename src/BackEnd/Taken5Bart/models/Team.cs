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
        public ICollection<Puzzel> Puzzellijst { get; set; } //op volgorde dat gedaan moet worden
        public int Score { get; set; }

        [JsonIgnore]
        public Sessie AssignedSessie { get; set; }
    }
}
