﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models.T5B
{
    public class Puzzel
    {
        public string naam { get; set; }
        public int Id { get; set; }
        public Locatie Locatie { get; set; }
        public int Diamant { get; set; }
        public String Uitleg { get; set; }

        //[JsonIgnore]
        //public ICollection<Team> AssignedTeams { get; set; }
        [JsonIgnore]
        public ICollection<PuzzelTeam> PuzzelTeams { get; } = new List<PuzzelTeam>();

        [JsonIgnore]
        public Game Game { get; set; }

    }
}
