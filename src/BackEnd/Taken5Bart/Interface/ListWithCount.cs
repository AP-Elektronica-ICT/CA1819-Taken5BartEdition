using Models.T5B;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interface.T5B
{
    public class TeamListWithCount
    {
        public int Count { get { return Data.Count(); } }
        public IEnumerable<Team> Data
        {
            get; set;
        }
    }
}
