using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taken5Bart.Controllers.Objects
{
    public class Puzzel
    {
        public int Id { get; set; }
        public Locatie Locatie { get; set; }
        public Game Game { get; set; }
        public int Diamant { get; set; }
    }
}
