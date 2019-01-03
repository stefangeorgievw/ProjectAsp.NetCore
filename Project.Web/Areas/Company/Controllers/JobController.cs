using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.Services.Contracts;
using Project.Web.Areas.Company.ViewModels;
using X.PagedList;

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
        public IActionResult Browse(int? page)
        {
            var companyUsername = this.User.Identity.Name;

            var jobs = this.jobService.GetWaitingForCompanyJobsWithSameCategories(companyUsername);

            var model = new BrowseJobsViewModel
            {
                Jobs = jobs,
            };

            var pageNumber = page ?? 1; 
            var onePageOfJobs = model.Jobs.ToPagedList(pageNumber, 7);

            

            return this.View(onePageOfJobs);
            
        }
    }
}