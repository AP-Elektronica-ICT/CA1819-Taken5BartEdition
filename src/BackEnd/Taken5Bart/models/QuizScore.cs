using System;
using System.Collections.Generic;
using System.Text;

namespace Models.T5B
{
    public class QuizScore
    {
        public int Id { get; set; }
        public string DeviceID { get; set; }
        public int AantalVragen { get; set; }
        public int Score { get; set; }
    }
}
