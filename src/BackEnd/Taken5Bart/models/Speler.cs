﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models.T5B
{
    public class Speler
    {
        public int Id { get; set; }
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public string DeviceId { get; set; }
        public bool InLoby { get; set; } = false;
        public bool InGame { get; set; } = false;
        public QuizScore quizScore { get; set; }

        [JsonIgnore]
        public Team AssignedTeam { get; set; }
    }
}
