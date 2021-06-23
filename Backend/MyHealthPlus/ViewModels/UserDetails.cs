using MyHealthPlus.Entities;
using System;

namespace MyHealthPlus.ViewModels
{
    public class UserDetails
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Sex { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}