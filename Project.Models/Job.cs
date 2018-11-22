using Project.Models.Enums;
using Project.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Models
{
   public class Job
    {
        public string Id { get; set; }

        public string UserId { get; set; }
        public IProfile User { get; set; }

        public string CompanyId { get; set; }
        public IProfile Company { get; set; }

        public JobStatus Status { get; set; }

        public decimal MaximumPrice { get; set; }

        public string Description { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        //Can be modified to City so can be searched by city
        public string Address { get; set; }

        public ICollection<Category> Categories { get; set; }



    }
}
