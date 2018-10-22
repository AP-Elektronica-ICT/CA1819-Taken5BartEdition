using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Team
    {
        public int Id { get; set; }
        public string TeamNaam { get; set; }
        public List<Speler> Spelers { get; set; }
        public int DiamantenVerzameld { get; set; }
        public List<Puzzel> Puzzellijst { get; set; } //op volgorde dat gedaan moet worden
        public int VerzameldeDiamanten { get; set; } //dient ook als pointer van de huidige puzzel
        public int Score { get; set; }

        [JsonIgnore]
        public Sessie AssignedSessie { get; set; }
    }
}
