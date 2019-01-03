using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.Services.Contracts;
using Project.Web.Areas.Company.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Web.Areas.Company.Controllers
{
    [Area("Company")]
    public class ProfileController:Controller
    {
        private IProfileService profileService;
        private IAccountService accountService;

        public ProfileController(IProfileService profileService, IAccountService accountService)
        {
            this.profileService = profileService;
            this.accountService = accountService;
        }

        [Authorize]
        public IActionResult Details(string id)
        {
            var companyProfile = this.profileService.GetCompanyProfile(id);

            if (companyProfile == null)
            {
                return this.Redirect("/");
            }

            
                var currentUsername = this.User.Identity.Name;
                var currentUserProfileId = this.profileService.GetUserProfileId(currentUsername);
                ViewBag.Id = currentUserProfileId;
            
            

          var  categories = string.Join(",", companyProfile.Categories.Select(x => x.Name));

            var model = new ProfileDetailsViewModel
            {
                Email = companyProfile.Account.Email,
                Description = companyProfile.Description,
                Name = companyProfile.Name,
                Account = companyProfile.Account,
                Rating = companyProfile.Rating,
                Categories = categories,
            };

            return this.View(model);
        }

        [HttpPost]
        public IActionResult Details(string companyName, double rateDigit)
        {
            

            var currentUserUsername = this.User.Identity.Name;

            var userProfile = this.profileService.GetUserProfile(currentUserUsername);

            var companyProfile = this.profileService.GetCompanyProfileWithName(companyName);

           

            this.profileService.Rate(userProfile, companyProfile, rateDigit);

            return this.Details(companyProfile.Id);
        }

        [Authorize(Roles ="Company")]
        public IActionResult MyProfile(string username)
        {
            if (this.User.Identity.Name != username)
            {
                return this.Redirect("/");
            }

           var companyProfile = this.profileService.GetCompanyProfileWithUsername(username);

            if (companyProfile == null)
            {
                return this.Redirect("/");
            }

            var categories = string.Join(",", companyProfile.Categories.Select(x => x.Name));

            var model = new ProfileDetailsViewModel
            {
                Email = companyProfile.Account.Email,
                Description = companyProfile.Description,
                Name = companyProfile.Name,
                Account = companyProfile.Account,
                Rating = companyProfile.Rating,
                Categories = categories,
            };

            return this.View(model);



        }
    }
}
