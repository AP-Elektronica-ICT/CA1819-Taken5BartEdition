using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taken5Bart.Controllers
{
    public class Game
    {
        public int Id { get; set; }
        public DateTime Datum { get; set; }
        public int Uur { get; set; }
        public Sessie Sessie { get; set; }
    }
}
