using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.T5B
{
    public class PuzzelTeam
    {
        //https://blog.oneunicorn.com/2017/09/25/many-to-many-relationships-in-ef-core-2-0-part-1-the-basics/
        public int TeamId { get; set; }
        public Team Team { get; set; }

        public int PuzzelId { get; set; }
        public Puzzel Puzzel { get; set; }
    }
}
