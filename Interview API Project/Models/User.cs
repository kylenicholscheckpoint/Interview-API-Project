using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interview_API_Project.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string DateOfBirth { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsActive { get; set; }
        public string SocialSecurityNumber { get; set; }
        public string role;
        public string UserType { get; set; } // Example values: "Admin", "User", "Guest"
    }

}
