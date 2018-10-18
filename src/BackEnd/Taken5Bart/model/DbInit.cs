using System;
using System.Collections.Generic;
using System.Text;

namespace model
{
    class DbInit
    {
        public static void Initialize(GameContext context)
        {
            context.Database.EnsureCreated();
            //maak items aan
            context.SaveChanges();
        }
    }
}
