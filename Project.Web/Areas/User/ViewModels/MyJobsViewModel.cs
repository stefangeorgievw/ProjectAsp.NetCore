using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Web.Areas.User.ViewModels
{
    public class MyJobsViewModel
    {
        public IEnumerable<Job> WaitingForCompanyJobs { get; set; } 

        public IEnumerable<Job> InProgressJobs { get; set; }
        
        public IEnumerable<Job> FinishedJobs { get; set; }
    }
}
