using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyHealthPlus.Entities
{
    public record AppointmentType
    {
        public int AppointmentTypeId { get; set; }
        public string Type { get; set; }
    }
}