using Microsoft.AspNetCore.Identity;
using Project.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Models
{
    public class Account : IdentityUser
    {
        public string ProfileId { get; set; }
        public IProfile Profile { get; set; }


    }
}
