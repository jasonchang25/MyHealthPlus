using MyHealthPlus.Entities;
using MyHealthPlus.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyHealthPlus.Repository
{
    public interface IAppointmentRepository : IDbRepository<Appointment>
    {
        public IEnumerable<Appointment> GetAllAppointments(); 
        public Appointment GetAppointmentById(int id);
        public IEnumerable<Appointment> GetAppointmentsByDate(DateTime date);
    }

    public class AppointmentRepository : DbRepository<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(MyHealthPlusContext db) : base(db)
        {
        }

        public Appointment GetAppointmentById(int id)
        {
            return Db.Appointments.Include(a => a.AppointmentType)
                                  .SingleOrDefault(a => a.AppointmentId == id);
        }

        public IEnumerable<Appointment> GetAppointmentsByDate(DateTime date)
        {
            return Db.Appointments.Include(a => a.AppointmentType)
                                  .Include(a => a.Session)
                                  .Where(a => a.AppointmentDate == date);
        }

        public IEnumerable<Appointment> GetAllAppointments()
        {
            var test = Db.Appointments.AsNoTracking()
                                      .Include(a => a.AppointmentType)
                                      .Include(a => a.Session)
                                      .Include(a => a.User);
            return test;
        }
    }
}
