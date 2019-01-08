using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.Common;
using Project.Services.Contracts;

namespace Project.Web.Areas.User.Controllers
{
    [Area(Constants.userRoleName)]
    public class OfferController:Controller
    {
        private IOfferService offerService;
        private IJobService jobService;

        public OfferController(IOfferService offerService, IJobService jobService)
        {
            this.offerService = offerService;
            this.jobService = jobService;
        }

        [Authorize(Roles = Constants.userRoleName)]
        public IActionResult AcceptOffer(string id)
        {
           var offer = this.offerService.GetOffer(id);
            if (offer == null)
            {
                return this.Redirect(Constants.homeUrl);
            }

           var result = this.jobService.AcceptOffer(offer);

            if (!result)
            {
                return this.Redirect(Constants.homeUrl);

            }

            return this.Redirect(Constants.userJobDetails + offer.JobId);
        }
    }
}
