using Project.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Web.Areas.User.ViewModels
{
    public class JobDetailsViewModel
    {
        
        public string Title { get; set; }

        public JobStatus Status { get; set; } 

        public decimal Price { get; set; }

        public string CompanyName { get; set; }

        public string Username { get; set; }

        public string Description { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string Address { get; set; }

    }
}
