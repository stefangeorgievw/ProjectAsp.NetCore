using Project.Models.Contracts;
using System;
using System.Collections.Generic;

namespace Project.Models
{
    public class CompanyProfile:IProfile
    {
        public CompanyProfile()
        {
            this.Categories = new HashSet<Category>();
           
        }

        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string AccountId { get; set; }
        public Account Account { get; set; }

        public string Name { get; set; }

        public Rating Rating { get; set; } 

        public string Description { get; set; }

        public IEnumerable<Category> Categories { get; set; }

        public IEnumerable<Job> Jobs { get; set; } = new HashSet<Job>();

        public IEnumerable<Contract> Contracts { get; set; } = new HashSet<Contract>();
    }
}
