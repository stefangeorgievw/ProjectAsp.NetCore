using Project.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.Web.Areas.User.ViewModels;
using Microsoft.AspNetCore.Identity;
using Project.Models;
using AutoMapper;
using Project.Models.Enums;

namespace Project.Web.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Roles = "User")]
    public class JobController : Controller
    {
        private IJobService jobService;
        private ICategoryService categoryService;
        private UserManager<Account> userManager;

        public JobController(IJobService jobService, UserManager<Account> userManager,
             ICategoryService categoryService)
        {
            this.userManager = userManager;
            this.jobService = jobService;
            this.categoryService = categoryService;
        }

        public IActionResult Create()
        {
            var categoriesNames = this.categoryService.GetAllCategoriesNames();
            var model = new CategoryNameViewModel()
            {
                CategoriesNames = categoriesNames
            };
            ViewBag.Categories = model;

            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateJobInputModel model)
        {
            if (!ModelState.IsValid || this.categoryService.IsCategoryValid(model.CategoryName) == false)
            {
                return this.View(model);
            }


            var currentUserName = this.User.Identity.Name;

            this.jobService.CreateJob(model.Title, model.Description, model.MaximumPrice, model.Address, currentUserName
                , model.CategoryName);

            return Redirect("MyJobs");
        }


        [HttpGet]
        public IActionResult MyJobs()
        {
            var currentUserName = this.User.Identity.Name;

            var waitingForCompanyJobs = this.jobService.GetJobs(currentUserName, JobStatus.WaitingForCompany);

            var inProgressJobs = this.jobService.GetJobs(currentUserName, JobStatus.InProgress);

            var finishedJobs = this.jobService.GetJobs(currentUserName, JobStatus.Finished);

            var model = new MyJobsViewModel()
            {
                WaitingForCompanyJobs = waitingForCompanyJobs,
                InProgressJobs = inProgressJobs,
                FinishedJobs = finishedJobs,
            };

            return this.View(model);
        }

        [HttpGet]
        public IActionResult Details(string id)
        {
            var job = this.jobService.GetJob(id);
            if (job == null)
            {
                return Redirect("Index");
            }

            var model = new JobDetailsViewModel
            {
                Title = job.Title,
                Address = job.Address,
                CompanyName = job.Company.Name,
                Description = job.Description,
                Price = job.Price,
                Status = job.Status,
                Username = job.User.Account.UserName,
                StartDate = job.StartDate,
                EndDate = job.EndDate,
            };

            return View(model);
        }
    }
}