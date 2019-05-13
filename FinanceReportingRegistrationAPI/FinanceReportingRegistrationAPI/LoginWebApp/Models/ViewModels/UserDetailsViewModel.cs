using DataAccess.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LoginWebApp.Models.ViewModels
{
    public class UserDetailsViewModel
    {
        public int Id { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Email address")]
        public string Email { get; set; }
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        public List<Role> Roles { get; set; } = new List<Role>();
    }
}
