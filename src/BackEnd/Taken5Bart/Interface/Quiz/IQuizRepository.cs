﻿using Models;
using Models.T5B;
using System;
using System.Collections.Generic;
using System.Text;


namespace Interface.T5B
{
    public interface IQuizRepository
    {
        ICollection<Quizvraag> GetQuizvragen();

        Quizvraag GetQuizvraag(int index);

    }
}