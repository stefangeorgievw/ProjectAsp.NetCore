using Project.Models.Interfaces;
using System;
using System.Collections.Generic;

namespace Project.Models
{
    public class UserProfile:IProfile
    {
        public UserProfile()
        {
            this.Contracts = new HashSet<Contract>();
            this.Jobs = new HashSet<Job>();
        }

        public string Id { get; set; } =  Guid.NewGuid().ToString();

        public string AccountId { get; set; }
        public Account Account { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<Job> Jobs { get; set; }

        public ICollection<Contract> Contracts { get; set; }
      
    }
}
