﻿using Project.Models.Interfaces;
using System;
using System.Collections.Generic;

namespace Project.Models
{
    public class UserProfile:IProfile
    {
       

        public string Id { get; set; } =  Guid.NewGuid().ToString();

        public string AccountId { get; set; }
        public Account Account { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<Job> Jobs { get; set; } = new HashSet<Job>();

        public ICollection<Contract> Contracts { get; set; } = new HashSet<Contract>();



    }
}
