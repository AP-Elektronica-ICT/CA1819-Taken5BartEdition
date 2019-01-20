using Models;
using Models.T5B;
using System;
using System.Text;
using System.Collections.Generic;

namespace Interface.T5B
{
    public interface ITeamRepository
    {
        ICollection<Team> GetTeams();
        void UpdateTeam(Team newTeam);
        Team GetTeam(int Id);
        void SetActivePuzzel(int tId, int pId);
        Team NewTeam(Team t);
        int GetStartPuzzel(int TeamId);

        //getstartpuzzelwithoutchange
        int GetActivePuzzel(int teamId);
        int GetNewPuzzel(int TeamId);
        int ChangeGameModus(int TeamId,int SpelerId);
        int DevChangeGameModus(int TeamId);
        Team AddPuzzels(Team team, ICollection<Puzzel> puzzels);
        ICollection<Puzzel> GetPuzzels(int teamId);
        int GameDone(int TeamId);

        //geeft totale quiz score van team terug
        double getquizscore(int TeamId);
    }
}