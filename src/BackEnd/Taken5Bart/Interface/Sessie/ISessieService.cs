using Models;
using Models.T5B;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interface.T5B
{
    public interface ISessieService
    {
        Sessie GetSessie(int Id);
        Sessie GetSessieByCode(string code);
        ICollection<Sessie> GetSessies();
        ICollection<Team> GetTeamsBySessie(string sessieId);
        string CreateSessie(Sessie newSessie);
        
    }
}
