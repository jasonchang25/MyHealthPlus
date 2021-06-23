using MyHealthPlus.Entities;
using MyHealthPlus.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyHealthPlus.Repository
{
    public interface ISessionRepository : IDbRepository<Session>
    {
    }

    public class SessionRepository : DbRepository<Session>, ISessionRepository
    {
        public SessionRepository(MyHealthPlusContext db) : base(db)
        {
        }
    }
}
