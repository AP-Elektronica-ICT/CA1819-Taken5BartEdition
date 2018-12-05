using Models.T5B;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interface
{
    public interface IPuzzelService
    {
        Puzzel GetPuzzel(int id);
        ICollection<Puzzel> GetPuzzels();
        Locatie GetLocatie(int id);
    }
}
