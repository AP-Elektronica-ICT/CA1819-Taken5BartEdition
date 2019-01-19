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
        public int TeamPositionId { get; set; }
        public int PuzzelDone { get; set; } //word gebruikt wanneer er het team een spel speelt en ze moeten wachten tot iedereen klaar is
        public int TeamMode { get; set; } //0: team in navigatiemodus; 1: spelers in start game room; 2: playing; 3: end of game
        public int StartPuzzel { get; set; }
        public Score PuzzelScores { get; set; }
        public int ActivePuzzel { get; set; } //hier word de voglende kuzzel bepaald
                                              //public ICollection<Int32> Puzzellijst { get; set; } //op volgorde dat gedaan moet worden
        [JsonIgnore]
        public ICollection<PuzzelTeam> PuzzelsTeam { get; } = new List<PuzzelTeam>();

        public int Score { get; set; }

        [JsonIgnore]
        public Sessie AssignedSessie { get; set; }
    }
}
