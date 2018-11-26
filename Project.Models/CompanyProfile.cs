﻿using Project.Models.Interfaces;
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

        public decimal Rating { get; set; } = Common.Constants.companyDefaultRating;

        public string Description { get; set; }

        public ICollection<Category> Categories { get; set; }

        public ICollection<Job> Jobs { get; set; } = new HashSet<Job>();

        public ICollection<Contract> Contracts { get; set; } = new HashSet<Contract>();
    }
}
