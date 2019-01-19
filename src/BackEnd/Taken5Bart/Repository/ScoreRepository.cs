using System.Collections.Generic;
using System.Linq;
using Interface.T5B;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.T5B;

namespace Repository.T5B
{
    public class ScoreRepository : IScoreRepository
    {
        GameContext _context;

        public ScoreRepository(GameContext context)
        {
            _context = context;
        }


        public Score GetAllScores(int teamId)
        {
            Team team = _context.Teams
                .Include(p => p.PuzzelScores)
                .FirstOrDefault(t => t.Id == teamId);

            if (team.PuzzelScores != null)
            {
                return team.PuzzelScores;
            }

            return null;

        }

        public int GetTotalScore(int teamId)
        {
            int totaalscore;
            Team team = _context.Teams
              .Include(p => p.PuzzelScores)
              .FirstOrDefault(t => t.Id == teamId);

            totaalscore = team.PuzzelScores.startgame + team.PuzzelScores.vlaamsekaai + team.PuzzelScores.stadsfeestzaal + team.PuzzelScores.Kathedraal + team.PuzzelScores.vleaykensgang + team.PuzzelScores.grotemarkt
                 + team.PuzzelScores.hetSteen + team.PuzzelScores.mas + team.PuzzelScores.havenhuis;

            return totaalscore;
        }

        public int SetScore(int teamId, string locatienaam, double score)
        {
            Team team = _context.Teams
            .Include(p => p.PuzzelScores)
            .FirstOrDefault(t => t.Id == teamId);

            switch (locatienaam)
            {
                case "startgame":
                    team.PuzzelScores.startgame = (int)score;
                    break;
                case "vlaamsekaai":
                    team.PuzzelScores.vlaamsekaai = (int)score;
                    break;
                case "stadsfeestzaal":
                    team.PuzzelScores.stadsfeestzaal = (int)score;
                    break;
                case "Kathedraal":
                    team.PuzzelScores.Kathedraal = (int)score;
                    break;
                case "vleaykensgang":
                    team.PuzzelScores.vleaykensgang = (int)score;
                    break;
                case "grotemarkt":
                    team.PuzzelScores.grotemarkt = (int)score;
                    break;
                case "hetSteen":
                    team.PuzzelScores.hetSteen = (int)score;
                    break;
                case "mas":
                    team.PuzzelScores.hetSteen = (int)score;
                    break;
                case "havenhuis":
                    team.PuzzelScores.hetSteen = (int)score;
                    break;
            }
            _context.SaveChanges();

            return (int)score;
        }

    }
}
