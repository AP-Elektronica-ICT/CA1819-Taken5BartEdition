using Models;
using System;
using System.Collections.Generic;
using System.Text;
using Interface;
using Models.T5B;
using Interface.T5B;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Repository.T5B
{
    public class TeamRepository : ITeamRepository
    {
        GameContext _context;

        public TeamRepository(GameContext context)
        {
            _context = context;
        }

        public Team NewTeam(Team t)
        {
            _context.Teams.Add(t);
            _context.SaveChanges();
            return t;
        }

        public Team GetTeam(int id)
        {
            return _context.Teams.Include(t => t.Spelers).Include(t => t.AssignedSessie).Include(t => t.PuzzelsTeam).ThenInclude(t => t.Puzzel).SingleOrDefault(g => g.Id == id);

        }

        public ICollection<Team> GetTeams()
        {
            return _context.Teams.Include(t => t.Spelers).Include(t => t.PuzzelsTeam).ThenInclude(t => t.Puzzel).ToList();
        }

        public void UpdateTeam(Team newTeam)
        {
            Team oldTeam = _context.Teams.Single(t => t.Id == newTeam.Id);
            oldTeam = newTeam;
            _context.SaveChanges();
        }

        public void SetActivePuzzel(int tId, int pId)
        {
            Team oldTeam = _context.Teams.Single(t => t.Id == tId);
            oldTeam.ActivePuzzel = pId;
            _context.SaveChanges();
        }

        public int GetStartPuzzel(int TeamId)
        {
            Team team = _context.Teams.Include(t => t.AssignedSessie).Single(t => t.Id == TeamId);
            int index = 0;
            System.Diagnostics.Debug.WriteLine(index);

            if (team.TeamPositionId == 0)
            {
                team.StartPuzzel = 1;
            }
            else
            {
                team.StartPuzzel = team.TeamPositionId + 2;
            }
            team.ActivePuzzel = team.StartPuzzel;
            _context.SaveChanges();
            return team.StartPuzzel;
        }

        public int GetNewPuzzel(int TeamId)
        {
            Team team = _context.Teams.Single(t => t.Id == TeamId);

            team.ActivePuzzel++;

            if (team.ActivePuzzel == team.StartPuzzel)
            {
                team.ActivePuzzel = 8;
            }
            else if (team.ActivePuzzel == 8 && team.StartPuzzel != 1)
            {
                team.ActivePuzzel = 1;
            }
            _context.SaveChanges();

            return team.ActivePuzzel;
        }

        public int ChangeGameModus(int TeamId)
        {
            Team team = GetTeam(TeamId);
            if (team.TeamMode == 0 || team.TeamMode == 2)
            {
                team.TeamMode++;
            }
            else if (team.TeamMode == 1 || team.TeamMode == 3)
            {
                if (team.Spelers.Count == team.PuzzelDone)
                {
                    if (team.TeamMode == 1)
                    {
                        team.TeamMode++;

                    }
                    else
                    {
                        team.TeamMode = 0;
                    }
                }
            }

            _context.SaveChanges();
            return team.TeamMode;
        }

        public int DevChangeGameModus(int TeamId)
        {
            Team team = GetTeam(TeamId);

            team.TeamMode++;


            _context.SaveChanges();
            return team.TeamMode;
        }


        public int GameDone(int TeamId)
        {
            Team team = GetTeam(TeamId);
            System.Diagnostics.Debug.WriteLine(team.PuzzelDone);

            team.PuzzelDone = team.PuzzelDone + 1;
            System.Diagnostics.Debug.WriteLine(team.PuzzelDone);
            _context.SaveChanges();
            return team.PuzzelDone;
        }

        public Team AddPuzzels(Team team, ICollection<Puzzel> puzzels)
        {
            foreach(Puzzel p in puzzels)
            {
                _context.Add(new PuzzelTeam { Puzzel = p, Team = team});
            }
            _context.SaveChanges();
            return team;
        }

        public ICollection<Puzzel> GetPuzzels(int teamId)
        {
            var team = _context.Teams.Include(t => t.Spelers).Include(t => t.AssignedSessie).Include(t => t.PuzzelsTeam).ThenInclude(t => t.Puzzel).ThenInclude(p=>p.Locatie).SingleOrDefault(g => g.Id == teamId);
            var puzzels = new List<Puzzel>();
            Debug.WriteLine(team.PuzzelsTeam.Count);
            foreach (PuzzelTeam p in team.PuzzelsTeam)
            {
                Debug.WriteLine(p.Puzzel.Id);
                Console.WriteLine(p.Puzzel.Id);
                Console.WriteLine(p.Team.TeamNaam);

                puzzels.Add(p.Puzzel);
            }
            return puzzels;
            /*
            var pt = _context.PuzzelTeams.Include(t => t.Team).Include(p => p.Puzzel);
            var puzzels = new List<Puzzel>();
            foreach(PuzzelTeam p in pt)
            {
                Console.WriteLine(p.Puzzel.Id);
                Console.WriteLine(p.Team.TeamNaam);
                if (p.TeamId == teamId)
                    puzzels.Add(p.Puzzel);
            }
            return puzzels;
            */
        }
    }
}
