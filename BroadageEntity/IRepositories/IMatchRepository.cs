﻿using BroadageEntity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BroadageEntity.IRepositories
{
    public interface IMatchRepository : IRepository<Match, int>
    {
        Task<List<Match>> GetMatchListAll();
    }
}
