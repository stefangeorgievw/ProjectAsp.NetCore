using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.Common;
using Project.Services.Contracts;
using Project.Web.Areas.Company.ViewModels;

namespace Project.Web.Areas.Company.Controllers
{
    [Area("Company")]
    public class ContractController : Controller
    {
        private IContractService contractService;
        private IJobService jobService;

        public ContractController(IContractService contractService, IJobService jobService)
        {
            this.contractService = contractService;
            this.jobService = jobService;
        }

        public IActionResult Upload(string id)
        {
            ViewBag.JobId = id;
            return this.View();
        }

        [HttpPost]
        [Authorize(Roles = Constants.companyRoleName)]
        public IActionResult Upload(UploadContractInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View();
            }

            var job = this.jobService.GetJob(model.JobId);

            if (job == null)
            {
                return this.View();
            }

            this.contractService.UploadContract(model.ContractFile, job);


            return this.Redirect(Constants.userJobDetails + model.JobId);
        }

        [Authorize]
        public IActionResult Download(string id)
        {
            var job = this.jobService.GetJob(id);
            if (job == null)
            {
                return this.Redirect(Constants.homeUrl);
            }

            var contract = this.contractService.GetContract(job);

            if (contract == null)
            {
                return this.Redirect(Constants.homeUrl);
            }

            return this.File(contract.Document, Constants.contractFormat, contract.Name);
        }
    }
}