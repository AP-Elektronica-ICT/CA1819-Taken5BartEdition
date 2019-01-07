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
            return _mmRepo.GetAllMasterminds();
        }

        public Mastermind NewGame(int teamId)
        {
            var oldM = _mmRepo.GetMasterMindByTeam(teamId);
            if(oldM == null)
            {
                Mastermind newM = new Mastermind()
                {
                    AssignedTeamId = teamId,
                    colorId1 = r.Next(colorRange),
                    colorId2 = r.Next(colorRange),
                    colorId3 = r.Next(colorRange),
                    colorId4 = r.Next(colorRange),
                    StartTime = DateTime.Now
                };
                Mastermind result = _mmRepo.NewGame(newM);
                return result;
            }
            return null;
        }

        public int[] TryAnswer(int teamId, Array answer)
        {
            var mm = _mmRepo.GetMasterMindByTeam(teamId);
            int[] mcolors =
            {
                mm.colorId1,
                mm.colorId2,
                mm.colorId3,
                mm.colorId4
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
            return result;
        }
    }
}
