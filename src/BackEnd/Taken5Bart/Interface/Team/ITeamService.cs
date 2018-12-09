﻿using Models;
using Models.T5B;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interface.T5B
{
    public interface ITeamService
    {
        Team GetTeam(int id);
        ICollection<Team> GetTeams();
        int GetScorePos(int id);
        bool SpelerJoin(int spelerId, int teamId);
        Puzzel ActivePuzzel(int Id);
        int ActivePuzzelID(int Id);
        Puzzel SetActivePuzzel(int Id, bool reset);
    }
}
