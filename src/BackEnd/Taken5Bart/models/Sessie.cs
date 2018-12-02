using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models.T5B
{
    public class Sessie
    {
        public int Id { get; set; }
        public ICollection<Team> Teams { get; set; }
        public DateTime StartTijd { get; set; }
        public string Code { get; set; }

        [JsonIgnore]
        public Sessie AssignedGame { get; set; }
    }
}
