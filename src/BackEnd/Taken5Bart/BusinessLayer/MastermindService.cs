using Interface.Puzzels;
using Models;
using Models.T5B;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    public class MastermindService : IMastermindService
    {
        private IMastermindRepository _mmRepo;
        const int colorRange = 7;
        const int mmAnswers = 4;
        Random r;
        public MastermindService(GameContext context)
        {
            _mmRepo = new MastermindRepository(context);
            r = new Random();
        }
        public ICollection<Mastermind> GetMasterMinds()
        {
            return _mmRepo.GetAllMastermind();
        }

        public Mastermind NewGame(Mastermind newM)
        {
            var oldM = _mmRepo.GetMasterMindByTeam(newM.AssignedTeamId);
            if(oldM == null)
            {
                Mastermind newMM = new Mastermind()
                {
                    AssignedTeamId = newM.AssignedTeamId,
                    AllDone= false,
                    ColorId1 = r.Next(colorRange),
                    ColorId2 = r.Next(colorRange),
                    ColorId3 = r.Next(colorRange),
                    ColorId4 = r.Next(colorRange),
                    StartTime = DateTime.Now
                };
                Mastermind result = _mmRepo.NewGame(newMM);
                return result;
            }
            return null;
        }

        public int[] TryAnswer(int teamId, Array answer)
        {
            var mm = _mmRepo.GetMasterMindByTeam(teamId);
            if(mm == null)
            {
                return new int[] { 0,0};
            }
            int[] mcolors =
            {
                mm.ColorId1,
                mm.ColorId2,
                mm.ColorId3,
                mm.ColorId4
            };
            int[] result = { 0, 0 };
            for (int i = 0; i < mmAnswers; i++)
            {
                if ((int)answer.GetValue(i) == mcolors[i])
                {
                    result[0]++;
                }
            }

            int[] tmpAnwser = (int[])mcolors.Clone();
            for (int i = 0; i < mmAnswers; i++)
            {
                bool notFound = true;
                for (int j = 0; j < mmAnswers; j++)
                {
                    if (((int)answer.GetValue(i) == tmpAnwser[j]) & notFound)
                    {
                        result[1]++;
                        tmpAnwser[j] = -1;
                        notFound = false;
                    }
                }
            }
            if(result[0] == mmAnswers)
            {
                _mmRepo.AddTry(mm.Id, true);
            }
            else
            {
                _mmRepo.AddTry(mm.Id, false);
            }
            return result;
        }

        public bool AllFound(int teamId)
        {
            var m = _mmRepo.GetMasterMindByTeam(teamId);
            if(m == null)
            {
                return false;
            }
            return m.AllDone;
        }

        public Mastermind GetMasterMindByTeam(int teamId)
        {
            return _mmRepo.GetMasterMindByTeam(teamId);
        }
    }
}
