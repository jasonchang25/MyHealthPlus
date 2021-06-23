using MyHealthPlus.ViewModels;
using MyHealthPlus.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Linq;
using System;

namespace MyHealthPlus.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpGet]
        public IActionResult GetAvailableSessions(DateTime appointmentDate)
        {
            var date = new DateTime(appointmentDate.Year, appointmentDate.Month, appointmentDate.Day);
            return Ok(_appointmentService.GetAvailableSession(date));
        }

        [HttpGet]
        public IActionResult GetAppointmentTypes()
        {
            return Ok(_appointmentService.GetAppointmentTypes());
        }

        [Authorize]
        [HttpPost]
        public IActionResult CreateAppointment(ViewModelAppointment appointment)
        {
            var date = appointment.AppointmentDate;
            appointment.AppointmentDate = new DateTime(date.Year, date.Month, date.Day);
            var availableSessions = _appointmentService.GetAvailableSession(appointment.AppointmentDate);

            // backend validation for double booking
            if (availableSessions.Select(x => x.SessionId).Contains(appointment.SessionId))
            {
                dynamic user = HttpContext.Items["User"];
                appointment.User = user;
                _appointmentService.CreateAppointment(appointment);
                return Ok(new { message = "Successfully submitted appointment" });
            }

            return BadRequest(new { message = "An appointment has already been made for the selected session time. Please refresh the page for updated options" });
        }

        [StaffAuthorize]
        [HttpPost]
        public IActionResult UpdateAppointmentComments(ViewModelAppointment appointment)
        {
            _appointmentService.UpdateAppointmentComments(appointment);
            return Ok(new { message = "Successfully updated appointment" });
        }


        [StaffAuthorize]
        [HttpGet]
        public IActionResult GetAllAppointments()
        {
            return Ok(_appointmentService.GetAllAppointments());
        }
    }
}
