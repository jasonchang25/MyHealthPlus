using MyHealthPlus.Entities;
using System;

namespace MyHealthPlus.ViewModels
{
    public class ViewModelAppointment
    {
        public int AppointmentId { get; set; }
        public User User { get; set; }
        public string AppointmentType { get; set; }
        public int AppointmentTypeId { get; set; }
        public Session Session { get; set; }
        public int SessionId { get; set; }
        public string Comments { get; set; }
        public DateTime AppointmentDate { get; set; }
    }
}