using Microsoft.EntityFrameworkCore;
using Project.Models;
using Project.Services.Contracts;
using Project.Web.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Services
{
    public class ProfileService:IProfileService
    {
        private ApplicationDbContext context;

        public ProfileService(ApplicationDbContext context)
        {
            this.context = context;
        }


       public CompanyProfile GetCompanyProfile(string id)
        {
            return this.context.CompaniesProfiles
                .Include(x => x.Rating)
                .Include(x => x.Account)
                .Include(x => x.Categories)
                .FirstOrDefault(x => x.Id == id);
        }

        public UserProfile GetUserProfile(string accountUsername)
        {
            return this.context.Users
                .Select(x=> x.UserProfile
            ).FirstOrDefault(x => x.Account.UserName == accountUsername);
        }

        public string GetUserProfileId(string username)
        {
            var userProfile = this.context.UserProfiles.FirstOrDefault(x => x.Account.UserName == username);
            return userProfile.Id;
        }

        public CompanyProfile GetCompanyProfileWithName(string companyProfileName)
        {
            return this.context.CompaniesProfiles
                .Include(x => x.Rating)
                
                .FirstOrDefault(x => x.Name == companyProfileName);
        }

        public void Rate(UserProfile userProfile, CompanyProfile companyProfile, double rateDigit)
        {
            companyProfile.Rating.RatingSum += rateDigit;
            companyProfile.Rating.CountOfVotes++;
            companyProfile.Rating.AverageRating = companyProfile.Rating.RatingSum / companyProfile.Rating.CountOfVotes;
            var userRaiting = new UserRating
            {
                RatingId = companyProfile.Rating.Id,
                Rating = companyProfile.Rating,
                UserProfile = userProfile,
                UserProfileId = userProfile.Id
            };
            userProfile.Ratings.Add(userRaiting);
            companyProfile.Rating.VotedUsers.Add(userRaiting);
            

            context.SaveChanges();
        }

        public CompanyProfile GetCompanyProfileWithUsername(string username)
        {
            return this.context.CompaniesProfiles
                .Include(x => x.Account)
                .Include(x=> x.Rating)
                .Include(x=> x.Categories)
                .FirstOrDefault(x => x.Account.UserName == username);
        }
    }
}
