using MyHealthPlus.Entities;
using MyHealthPlus.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyHealthPlus.Repository
{
    public interface IAppointmentTypeRepository : IDbRepository<AppointmentType>
    {
    }

    public class AppointmentTypeRepository : DbRepository<AppointmentType>, IAppointmentTypeRepository
    {
        public AppointmentTypeRepository(MyHealthPlusContext db) : base(db)
        {
        }
    }
}
