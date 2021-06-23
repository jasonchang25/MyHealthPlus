using MyHealthPlus.Entities;
using MyHealthPlus.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyHealthPlus.Repository
{
    public interface IUserRepository : IDbRepository<User>
    {
        public User GetUserById(int id);
        public User GetUserByLogin(string email, string password);
        public User GetUserByEmail(string email);
    }

    public class UserRepository : DbRepository<User>, IUserRepository
    {
        public UserRepository(MyHealthPlusContext db) : base(db)
        {
        }

        public User GetUserById(int id)
        {
            return Db.Users.Include(u => u.UserType)
                           .SingleOrDefault(u => u.UserId == id);
        }

        public User GetUserByEmail(string email)
        {
            return Db.Users.Include(u => u.UserType)
                           .SingleOrDefault(u => u.Email == email);
        }

        public User GetUserByLogin(string email, string password)
        {
            return Db.Users.Include(u => u.UserType)
                           .SingleOrDefault(u => u.Email == email && u.Password == password);
        }
    }
}
