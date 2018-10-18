using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taken5Bart.Controllers.Objects
{
    public class Game
    {
        public int Id { get; set; }
        public DateTime Datum { get; set; }
        public int uur { get; set; }
        public Sessie Sessie { get; set; }
    }
}
