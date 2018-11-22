using Project.Models.Interfaces;
using System;
using System.Collections.Generic;

namespace Project.Models
{
    public class UserProfile:IProfile
    {
        public string Id { get; set; } =  Guid.NewGuid().ToString();

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<Job> Jobs { get; set; }

        public ICollection<Contract> Contracts { get; set; }
      
    }
}
