using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class DbInit
    {
        public static void Initialize(GameContext context)
        {
            context.Database.EnsureCreated();
            //maak items aan
            context.SaveChanges();
            var sessie = new Sessie { Teams = null, StartTijd = DateTime.Now };
            context.Games.AddRange(
                new Game {MogelijkePuzzels = null, Stad = "Antwerpen", Sessie = { sessie } }
                );
            context.SaveChanges();
        }
    }
}
