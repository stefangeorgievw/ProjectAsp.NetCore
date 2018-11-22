using Project.Models.Interfaces;
using System;
using System.Collections.Generic;

namespace Project.Models
{
    public class CompanyProfile:IProfile
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string Name { get; set; }

        public int Rating { get; set; } = Common.Constants.companyDefaultRating;


        public ICollection<Job> Jobs { get; set ; }

        public ICollection<Contract> Contracts { get; set ; }

        public ICollection<Category> Categories { get; set; }
    }
}
