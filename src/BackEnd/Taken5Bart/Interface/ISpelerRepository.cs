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
        Speler GetSpelerOnDevice(string DeviceID);

        void NewSpeler(Speler s);
        void PostSpeler(Speler s);
        string CheckRegisterdPlayer(Speler id);
        ICollection<Speler> GetSpelers();
    }
}
