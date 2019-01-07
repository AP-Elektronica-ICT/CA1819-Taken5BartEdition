using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Mastermind
    {
        public int id { get; set; }
        public DateTime StartTime { get; set; }
        public int colorId1 { get; set; }
        public int colorId2 { get; set; }
        public int colorId3 { get; set; }
        public int colorId4 { get; set; }
        public int AssignedTeamId { get; set; }
    }
}
