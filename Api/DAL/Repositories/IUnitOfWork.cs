﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.DAL.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> CommitAsync();
    }
}
