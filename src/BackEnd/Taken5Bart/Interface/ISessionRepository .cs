using Models;
using Models.T5B;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interface.T5B
{
    public interface ISessionRepository
    {
        Sessie GetSessie(int id);
        IEnumerable<Sessie> GetSessies();

    }
}
