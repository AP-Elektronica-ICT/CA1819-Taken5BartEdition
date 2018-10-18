using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    class DbInit
    {
        public static void Initialize(GameContext context)
        {
            context.Database.EnsureCreated();
            //maak items aan
            context.SaveChanges();
            var sessie = new Sessie { Teams = null, Winnaar = null };
            context.Games.AddRange(
                new Game { Datum = DateTime.Now, Uur = 0, Sessie = sessie }
                );
            context.SaveChanges();
        }
    }
}
