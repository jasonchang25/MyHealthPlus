using MyHealthPlus.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHealthPlus.Persistence
{
    public partial class MyHealthPlusContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite("Data Source=MyHealthPlus.db");
        //protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlServer("Server=LocalHost\\SQLExpress;database=MyHealthPlus;Integrated Security=true;");

        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<AppointmentType> AppointmentTypes { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var userTypes = new UserType[]
            {
                new UserType { UserTypeId = 1, Type = "Admin"},
                new UserType { UserTypeId = 2, Type = "Staff"},
                new UserType { UserTypeId = 3, Type = "Client"}
            };

            var appointmentTypes = new AppointmentType[]
            {
                new AppointmentType { AppointmentTypeId = 1, Type = "General Check Up"},
                new AppointmentType { AppointmentTypeId = 2, Type = "Skin Cancer Check"}
            };

            var sessions = new Session[]
            {
                new Session { SessionId = 1, StartTime = new TimeSpan(9,0,0), EndTime = new TimeSpan(10,0,0)},
                new Session { SessionId = 2, StartTime = new TimeSpan(10,0,0), EndTime = new TimeSpan(11,0,0)},
                new Session { SessionId = 3, StartTime = new TimeSpan(11,0,0), EndTime = new TimeSpan(12,0,0)},
                new Session { SessionId = 4, StartTime = new TimeSpan(12,0,0), EndTime = new TimeSpan(13,0,0)},
                new Session { SessionId = 5, StartTime = new TimeSpan(13,0,0), EndTime = new TimeSpan(14,0,0)},
                new Session { SessionId = 6, StartTime = new TimeSpan(14,0,0), EndTime = new TimeSpan(15,0,0)},
                new Session { SessionId = 7, StartTime = new TimeSpan(15,0,0), EndTime = new TimeSpan(16,0,0)},
                new Session { SessionId = 8, StartTime = new TimeSpan(16,0,0), EndTime = new TimeSpan(17,0,0)}
            };

            var users = new User[]
            {
                new User { UserId = 1, UserTypeId =  1, Email = "admin@myhealthplus.com", Password = "Admin123", FirstName = "Bob", LastName = "Boss", PhoneNumber = "0400123456", Sex = "Male", DateOfBirth = new DateTime(1985,1,1)},
                new User { UserId = 2, UserTypeId =  2, Email = "staff@myhealthplus.com", Password = "Staff123", FirstName = "Amy", LastName = "Stake", PhoneNumber = "0401234567", Sex = "Female", DateOfBirth = new DateTime(1991,2,3)},
                new User { UserId = 3, UserTypeId =  3, Email = "client@gmail.com", Password = "Client123",  FirstName = "Hugh", LastName = "Mungus", PhoneNumber = "0412345678", Sex = "Male", DateOfBirth = new DateTime(1997,10,26)}
            };

            var appointments = new Appointment[]
            {
                new Appointment { AppointmentId = 1, UserId = 3, SessionId = 3, AppointmentTypeId = 1, AppointmentDate = new DateTime(2021, 6, 28), Comments = "" },
                new Appointment { AppointmentId = 2, UserId = 3, SessionId = 1, AppointmentTypeId = 2, AppointmentDate = new DateTime(2021, 7, 10), Comments = "" },
            };

            modelBuilder.Entity<UserType>().HasData(userTypes);
            modelBuilder.Entity<AppointmentType>().HasData(appointmentTypes);
            modelBuilder.Entity<Session>().HasData(sessions);
            modelBuilder.Entity<User>().HasData(users);
            modelBuilder.Entity<Appointment>().HasData(appointments);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
