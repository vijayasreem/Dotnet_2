using System;
using System.ComponentModel.DataAnnotations;

namespace DotNetNamespace
{
    public class UserRegistrationModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Required]
        public string MobileNumber { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Role { get; set; }

        [Required]
        public string Level { get; set; }

        public string Notes { get; set; }

        [Required]
        public bool IsActive { get; set; }
    }
}