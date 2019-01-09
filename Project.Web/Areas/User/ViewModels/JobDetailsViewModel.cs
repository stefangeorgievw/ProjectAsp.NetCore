using Project.Models;
using Project.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Web.Areas.User.ViewModels
{
    public class JobDetailsViewModel
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public JobStatus Status { get; set; } 

        public decimal Price { get; set; }

        public Contract Contract { get; set; }

        public Category Category { get; set; }

        public CompanyProfile Company { get; set; }

        public string Email { get; set; }

        public string Description { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string Address { get; set; }

    }
}
