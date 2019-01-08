using Project.Models;
using System.Collections.Generic;

namespace Project.Web.Areas.Company.ViewModels
{
    public class MyJobsViewModel
    {
        public IEnumerable<Job> InProgressJobs { get; set; }

        public IEnumerable<Job> FinishedJobs { get; set; }
    }
}
