using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.Common;
using Project.Services.Contracts;
using Project.Web.Areas.Company.ViewModels;

namespace Project.Web.Areas.Company.Controllers
{
    [Area(Constants.companyRoleName)]
    public class OfferController : Controller
    {
        private IOfferService offerService;

        public OfferController(IOfferService offerService)
        {
            this.offerService = offerService;
        }

        [Authorize(Roles = Constants.companyRoleName)]
        public IActionResult Create(string id)
        {
            ViewBag.Id = id;
            return View();
        }

        [Authorize(Roles = Constants.companyRoleName)]
        [HttpPost]
        public IActionResult Create(CreateOfferInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }
            var username = this.User.Identity.Name;
            this.offerService.CreateOffer(model.Price, model.StartDate, model.EndDate, model.Comment, model.JobId,username);


            return this.Redirect(Constants.homeUrl);
        }
    }
}