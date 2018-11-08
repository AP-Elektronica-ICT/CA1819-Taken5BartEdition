﻿using Models;
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
    public class SessieRepository:ISessionRepository
    {
        GameContext _context;

        public SessieRepository(GameContext context)
        {
            _context = context;
        }

        public Sessie GetSessie(int id)
        {
            Sessie sessie = _context.Sessies.Include(s => s.Teams).SingleOrDefault(s => s.Id == id);
            return sessie;
        }

        public IEnumerable<Sessie> GetSessies()
        {
            var sessie = _context.Sessies.Include(s => s.Teams);
            return sessie;
        }

        public IEnumerable<Team> GetTeams(int sessieId)
        {
            var sessie = _context.Sessies.Include(s => s.Teams).SingleOrDefault(s => s.Id == sessieId);
            if(sessie != null)
            {
                var t = sessie.Teams;
            }
            return t;
        }
    }
}