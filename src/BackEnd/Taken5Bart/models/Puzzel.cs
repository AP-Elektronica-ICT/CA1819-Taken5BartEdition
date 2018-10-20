﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Puzzel
    {
        public int Id { get; set; }
        public Locatie Locatie { get; set; }
        public Game Game { get; set; }
        public int Diamant { get; set; }
        [JsonIgnore]
        public Team AssignedTeams { get; set; }
    }
}
