using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventManagmentWeb.Models
{
    public class UserProfile
    {
        public int? UserID { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("User Name")]
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [DisplayName("Collage Name")]
        public Nullable<int> CollageID { get; set; }
        public Nullable<int> RoleID { get; set; }
    }
}