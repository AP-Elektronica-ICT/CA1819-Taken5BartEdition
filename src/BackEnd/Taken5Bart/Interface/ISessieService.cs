﻿using Models;
using Models.T5B;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interface.T5B
{
    public interface ISessieService
    {
        Sessie GetSessie(int Id);
        ICollection<Sessie> GetSessies();
        ICollection<Team> GetTeamsBySessie(int sessieId);
        bool CreateSessie(Sessie newSessie);
    }
}
