using Project.Models.Enums;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Project.Models
{
   public class Job
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string UserId { get; set; }
        public UserProfile User { get; set; }

        public string CompanyId { get; set; }
        public CompanyProfile Company { get; set; } = null;

        public JobStatus Status { get; set; } = JobStatus.WaitingForCompany;

        public decimal Price { get; set; }

        public IEnumerable<Offer> Offers { get; set; }

        public string Description { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        //Can be modified to City so can be searched by city
        public string Address { get; set; }

        public string CategoryId { get; set; }
        public Category Category { get; set; }

        public DateTime DateOfCreation { get; set; } = DateTime.UtcNow;

        public Contract Contract { get; set; }



    }
}
