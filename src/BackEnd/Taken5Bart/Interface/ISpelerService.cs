using Models;
using Models.T5B;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interface.T5B
{
    public interface ISpelerService
    {
        IEnumerable<Speler> GetSpelers();
        Speler GetSpeler(int id);
        Team GetTeamFromSpeler(int spelerId);
    }
}
