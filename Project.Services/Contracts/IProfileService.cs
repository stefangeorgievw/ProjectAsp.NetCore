using Project.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.Services.Contracts
{
    public interface IProfileService
    {
        CompanyProfile GetCompanyProfile(string id);

        UserProfile GetUserProfile(string accountUsername);

        CompanyProfile GetCompanyProfileWithName(string companyProfileName);

        string GetUserProfileId(string username);

         void Rate(UserProfile userProfile, CompanyProfile companyProfile, double rateDigit);

        CompanyProfile GetCompanyProfileWithUsername(string username);
    }
}
