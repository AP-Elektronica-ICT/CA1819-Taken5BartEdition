using Models;
using Models.T5B;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interface.T5B
{
    public interface ISpelerRepository
    {
        Speler GetSpeler(int Id);
        Team GetTeamFromSpeler(int spelerId);
        void NewSpeler(Speler s);
    }
}
