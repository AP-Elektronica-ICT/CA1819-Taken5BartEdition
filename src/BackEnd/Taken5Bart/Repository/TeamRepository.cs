using Models;
using System;
using System.Collections.Generic;
using System.Text;
using Interface;
using Models.T5B;
using Interface.T5B;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Repository.T5B
{
    public class TeamRepository: ITeamRepository
    {
        GameContext _context;

        public TeamRepository(GameContext context)
        {
            _context = context;
        }

        public void NewTeam(Team t)
        {
            _context.Teams.Add(t);
            _context.SaveChanges();
        }

        public Team GetTeam(int id)
        {
            return _context.Teams.Include(t=>t.Spelers).Include(t=>t.Puzzellijst).Include(t => t.AssignedSessie).SingleOrDefault(g => g.Id == id);

        }

        public ICollection<Team> GetTeams()
        {
            return _context.Teams.Include(t => t.Spelers).Include(t => t.Puzzellijst).ToList();
        }

        public void UpdateTeam(Team newTeam)
        {
            Team oldTeam = _context.Teams.Single(t => t.Id == newTeam.Id);
            oldTeam = newTeam;
            _context.SaveChanges();
        }

        public Team NewTeamT(Team t)
        {
            _context.Teams.Add(t);
            _context.SaveChanges();
            return t;
        }

        public int GetStartPuzzel(int TeamId)
        {
            
            Team team = _context.Teams.Include(t => t.AssignedSessie).Single(t => t.Id == TeamId);
           /* Sessie sessie = _context.Sessies.Include(t => t.Teams).SingleOrDefault(s => s.Id == team.AssignedSessie.Id);
            ICollection<Team> teams = sessie.Teams;
            teams.OrderBy(x => x.Id);
            System.Diagnostics.Debug.WriteLine(teams);
            IList<Team> teamsL = teams.ToList();*/
            int index = 0;
/*
            for (int i = 0; i < teamsL.Count; i++)
            {
                System.Diagnostics.Debug.WriteLine(("cijfers voor teamid " + TeamId));

                System.Diagnostics.Debug.WriteLine((teamsL[i].Id));
                System.Diagnostics.Debug.WriteLine(team.Id);
                System.Diagnostics.Debug.WriteLine("");

                if (teamsL[i].Id == team.Id)
                {
                   

                }
            }
         */

            

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

            if(team.ActivePuzzel == team.StartPuzzel)
            {
                team.ActivePuzzel = 8;
            }
            else if ( team.ActivePuzzel == 8 && team.StartPuzzel != 1)
            {
                team.ActivePuzzel = 1;
            }
            _context.SaveChanges();

            return team.ActivePuzzel;
        }
    }
}
