using Models.T5B;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interface
{
    public interface IPuzzelRepository
    {
        Puzzel GetPuzzel(int id);
        ICollection<Puzzel> GetPuzzels();
    }
}
