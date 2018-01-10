﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventManagmentWeb.Models
{
    public class UserProfile
    {
        public int? UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public Nullable<int> CollageID { get; set; }
    }
}