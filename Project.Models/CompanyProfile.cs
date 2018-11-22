using Project.Models.Interfaces;
using System;
using System.Collections.Generic;

namespace Project.Models
{
    public class CompanyProfile:IProfile
    {
        public CompanyProfile()
        {
            this.Categories = new HashSet<Category>();
            this.Contracts = new HashSet<Contract>();
            this.Jobs = new HashSet<Job>();
        }

        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string AccountId { get; set; }
        public Account Account { get; set; }

        public string Name { get; set; }

        public int Rating { get; set; } = Common.Constants.companyDefaultRating;


        public ICollection<Job> Jobs { get; set ; }

        public ICollection<Contract> Contracts { get; set ; }

        public ICollection<Category> Categories { get; set; }
    }
}
