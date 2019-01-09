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
        void CreateSpeler(Speler newSpeler);
        Team GetTeamFromSpeler(int spelerId);
        Sessie GetSessieFromSpeler(int spelerId);


        Speler GetSpeler(int id);
        Speler GetSpelerOnDeviceID(string deviceId);

    }
}
