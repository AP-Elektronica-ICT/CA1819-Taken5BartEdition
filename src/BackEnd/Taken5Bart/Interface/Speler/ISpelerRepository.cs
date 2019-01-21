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
        Speler NewSpeler(Speler s);
        ICollection<Speler> GetSpelers();

        void PostQuizScore(int Spelerid, QuizScore Q);

        void DeleteSpeler(int id);

    }
}
