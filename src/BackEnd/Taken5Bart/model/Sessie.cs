using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taken5Bart.Controllers
{
    public class Sessie
    {
        public int Id { get; set; }
        public List<Team> Teams { get; set; }
        public Team Winnaar { get; set; }
    }
}
