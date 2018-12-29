using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.Services.Contracts;
using Project.Web.Areas.Company.ViewModels;

namespace Project.Web.Areas.Company.Controllers
{
    [Area("Company")]
    public class JobController : Controller
    {
        private IJobService jobService;

        public JobController(IJobService jobService)
        {
            this.jobService = jobService;
        }

        [Authorize(Roles = "Company")]
        public IActionResult Browse()
        {
            var companyUsername = this.User.Identity.Name;

            var jobs = this.jobService.GetJobsWithSameCategories(companyUsername);

            var model = new BrowseJobsViewModel
            {
                Jobs = jobs,
            };

            return this.View(model);
            
        }
    }
}