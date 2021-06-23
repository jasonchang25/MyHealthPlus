using MyHealthPlus.Entities;
using MyHealthPlus.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyHealthPlus.Repository
{
    public interface IUserTypeRepository : IDbRepository<UserType>
    {
        public UserType GetUserType(string userType);
    }

    public class UserTypeRepository : DbRepository<UserType>, IUserTypeRepository
    {
        public UserTypeRepository(MyHealthPlusContext db) : base(db)
        {
        }

        public UserType GetUserType(string userType)
        {
            return Db.UserTypes.SingleOrDefault(ut => ut.Type == userType);
        }
    }
}
