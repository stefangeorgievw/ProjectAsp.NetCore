using Microsoft.AspNetCore.Identity;
using Project.Models.Contracts;
using System.Collections.Generic;

namespace Project.Models
{
    public class Account : IdentityUser
    {
        public string UserProfileId { get; set; }
        public UserProfile UserProfile { get; set; } = null;

        public string CompanyProfileId { get; set; }
        public CompanyProfile CompanyProfile { get; set; } = null;

      
    }
}
