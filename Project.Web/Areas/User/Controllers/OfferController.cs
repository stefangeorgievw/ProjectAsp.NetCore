using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Web.Areas.User.Controllers
{
    [Area("User")]
    public class OfferController:Controller
    {
        private IOfferService offerService;
        private IJobService jobService;

        public OfferController(IOfferService offerService, IJobService jobService)
        {
            this.offerService = offerService;
            this.jobService = jobService;
        }

        [Authorize(Roles ="User")]
        public IActionResult AcceptOffer(string id)
        {
           var offer = this.offerService.GetOffer(id);
            if (offer == null)
            {
                return this.Redirect("/");
            }

           var result = this.jobService.AcceptOffer(offer);

            if (!result)
            {
                return this.Redirect("/");

            }

            return this.Redirect($"~/User/Job/Details?id={offer.JobId}");
        }
    }
}
