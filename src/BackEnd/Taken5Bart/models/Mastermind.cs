using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Mastermind
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public bool AllDone { get; set; }
        public int ColorId1 { get; set; }
        public int ColorId2 { get; set; }
        public int ColorId3 { get; set; }
        public int ColorId4 { get; set; }
        public int AssignedTeamId { get; set; }
        public int Trials { get; set; }
    }
}
