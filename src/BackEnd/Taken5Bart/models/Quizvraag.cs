using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models.T5B
{
    public class Quizvraag
    {
        public int Id { get; set; }
        public int Vraagnummer { get; set; }
        public String Vraag { get; set; }
        public String Antwoord1 { get; set; }
        public String Antwoord2 { get; set; }

        public String Antwoord3 { get; set; }
        public String Antwoord4 { get; set; }
        public String Antwoord5 { get; set; }
        public String Antwoord6 { get; set; }
        public int Correctie { get; set; }
        public int AantalKeerGeraden { get; set; }
        public bool JuistGeraden { get; set; }
    }
}
