using Models;
using Models.T5B;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interface.T5B
{
    public interface ISpelerService
    {
        ICollection<Speler> GetSpelers();
        Speler GetSpeler(int id);
        void CreateSpeler(Speler newSpeler);
        Team GetTeamFromSpeler(int spelerId);
    }
}
