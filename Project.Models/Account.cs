using Microsoft.AspNetCore.Identity;
using Project.Models.Contracts;
using System;
using System.Collections.Generic;

namespace Project.Models
{
    public class Account : IdentityUser
    {
        public string UserProfileId { get; set; }
        public UserProfile UserProfile { get; set; } 

        public string CompanyProfileId { get; set; }
        public CompanyProfile CompanyProfile { get; set; }

        public DateTime DateOfCreation { get; set; } = DateTime.UtcNow;


    }
}
