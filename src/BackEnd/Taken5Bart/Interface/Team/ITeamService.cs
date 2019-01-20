using Models;
using Models.T5B;
using System;
using System.Text;
using System.Collections.Generic;

namespace Interface.T5B
{
    public interface ITeamService
    {
        Team GetTeam(int id);
        ICollection<Team> GetTeams();
        int GetScorePos(int id);
        bool SpelerJoin(int spelerId, int teamId);
        int GetStartPuzzel(int TeamId);
        int GetActivePuzzel(int teamId);

        int GetNewPuzzel(int TeamId);
        Puzzel ActivePuzzel(int Id);
        int ActivePuzzelID(int Id);
        Puzzel SetActivePuzzel(int Id, bool reset);

        int ChangeGameModus(int TeamId, int SpelerId);
        int DevChangeGameModus(int TeamId); //for development 
        int GameDone(int TeamId);
        //geeft totale quiz score van team terug
        double getquizscore(int TeamId);
        ICollection<Puzzel> GetPuzzels(int TeamId);
    }
}