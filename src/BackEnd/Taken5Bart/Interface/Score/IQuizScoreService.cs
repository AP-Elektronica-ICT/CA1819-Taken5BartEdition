﻿using Microsoft.AspNetCore.Mvc;
using Models.T5B;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interface.T5B
{
    public interface IQuizScoreService
    {
        ICollection<QuizScore> GetQuizScores();
        ICollection<QuizScore> GetTeamQuizScores();

        void AddNewScore(QuizScore Q);
    }
}
