using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.Common;
using Project.Models.Enums;
using Project.Services.Contracts;
using Project.Web.Areas.Company.ViewModels;
using X.PagedList;

namespace Project.Web.Areas.Company.Controllers
{
    [Area(Constants.companyRoleName)]
    public class JobController : Controller
    {
        private IJobService jobService;

        public JobController(IJobService jobService)
        {
            this.jobService = jobService;
        }

        [Authorize(Roles = Constants.companyRoleName)]
        public IActionResult Browse(int? page)
        {
            var companyUsername = this.User.Identity.Name;

            var jobs = this.jobService.GetWaitingForCompanyJobsWithSameCategories(companyUsername);

            var model = new BrowseJobsViewModel
            {
                Jobs = jobs,
            };

            var pageNumber = page ?? 1; 
            var onePageOfJobs = model.Jobs.ToPagedList(pageNumber, 4);

            
            
            return this.View(onePageOfJobs);
            
        }

        [Authorize(Roles = Constants.companyRoleName)]
        public IActionResult MyJobs()
        {
            var currentCompanyUsername = this.User.Identity.Name;

            this.jobService.FinishCompanyJobs(currentCompanyUsername);

            var inProgressJobs = this.jobService.GetCompanyJobs(currentCompanyUsername, JobStatus.InProgress);

            var finishedJobs = this.jobService.GetCompanyJobs(currentCompanyUsername, JobStatus.Finished);

            var model = new MyJobsViewModel()
            {
                InProgressJobs = inProgressJobs,
                FinishedJobs = finishedJobs,
            };

            return this.View(model);
        }
    }
}