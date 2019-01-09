using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Models.T5B
{
    public class GameContext: DbContext
    {
        public GameContext(DbContextOptions<GameContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //  modelBuilder.Entity<Movie>().ToTable("Movie");
            // modelBuilder.Entity<Rating>().ToTable("Rating");
            modelBuilder.Entity<Game>().ToTable("Game");
            modelBuilder.Entity<PuzzelTeam>()
        .HasKey(t => new { t.PuzzelId, t.TeamId });

        }


        public DbSet<Game> Games { get; set; }
        public DbSet<Locatie> Locaties { get; set; }
        public DbSet<Puzzel> Puzzels { get; set; }
        public DbSet<PuzzelTeam> PuzzelTeams { get; set; }
        public DbSet<Sessie> Sessies { get; set; }
        public DbSet<Speler> Spelers { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Quizvraag> Quizvragen { get; set; }
        public DbSet<QuizScore> QuizScores { get; set; }
        public DbSet<FindTheDifference> FindTheDifferences { get; set; }
        public DbSet<FindTheDifferenceItem> FindTheDifferenceItems { get; set; }
        public DbSet<SteenScore> SteenScores { get; set; }
        public DbSet<PhotoGameScore> PhotoGameScores { get; set; }
        public DbSet<VlaeykensScore> VlaeykensScores { get; set; }
    }
}
