using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interface;
using Interface.T5B;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.T5B;
using Repository;
using Repository.T5B;
namespace BusinessLayer.T5B
{
    public class ScoreService : IScoreService
    {
        private IScoreRepository _scoreRepo;

        public ScoreService(GameContext context)
        {
            _scoreRepo = new ScoreRepository(context);
        }
        public Score GetAllScores(int teamId)
        {
            return _scoreRepo.GetAllScores(teamId);
        }

        public int GetTotalScore(int teamId)
        {
            return _scoreRepo.GetTotalScore(teamId);
        }

        public int SetScore(int teamId, string locatienaam, double score)
        {
            return _scoreRepo.SetScore(teamId,locatienaam,score);
        }
    }
}
