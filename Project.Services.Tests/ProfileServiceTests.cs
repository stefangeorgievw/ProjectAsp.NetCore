using Microsoft.EntityFrameworkCore;
using Project.Models;
using Project.Services.Contracts;
using Project.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Project.Services.Tests
{
    public class ProfileServiceTests
    {
        [Fact]
        public void GetCompanyProfileShoudlReturnProfileTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
           .UseInMemoryDatabase(databaseName: "Get_CompanyProfile")
           .Options;

            var company = new CompanyProfile { Id = "companyId" };
            CompanyProfile companyProfile;

            using (var context = new ApplicationDbContext(options))
            {
                context.CompaniesProfiles.Add(company);
                context.SaveChanges();

                IProfileService service = new ProfileService(context);
                companyProfile = service.GetCompanyProfile("companyId");
               
            }

            Assert.Equal(company.Id, companyProfile.Id);


        }

        [Fact]
        public void GetCompanyProfileShoudlReturnNullTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
           .UseInMemoryDatabase(databaseName: "Get_CompanyProfile_Null")
           .Options;


            CompanyProfile companyProfile;

            using (var context = new ApplicationDbContext(options))
            {
                IProfileService service = new ProfileService(context);
                companyProfile = service.GetCompanyProfile("companyId");

            }

            Assert.Null(companyProfile);


        }

        [Fact]
        public void GetUserProfileTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
           .UseInMemoryDatabase(databaseName: "Get_UserProfile")
           .Options;

            var profile = new UserProfile
            {
                Account = new Account
                {
                    UserName = "username"
                }
            };

            UserProfile userProfile;

            using (var context = new ApplicationDbContext(options))
            {
                context.UserProfiles.Add(profile);
                context.SaveChanges();

                IProfileService service = new ProfileService(context);
                userProfile = service.GetUserProfile("username");

            }

            Assert.Equal("username",userProfile.Account.UserName);


        }

        [Fact]
        public void GetUserProfileIdTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
           .UseInMemoryDatabase(databaseName: "Get_UserProfileId")
           .Options;

            var profile = new UserProfile
            {
                Id = "id",
                Account = new Account
                {
                    UserName = "username"
                }
            };

            string userProfileId;

            using (var context = new ApplicationDbContext(options))
            {
                context.UserProfiles.Add(profile);
                context.SaveChanges();

                IProfileService service = new ProfileService(context);
                userProfileId = service.GetUserProfileId("username");

            }

            Assert.Equal(profile.Id, userProfileId);

        }

        [Fact]
        public void GetCompanyProfileWithNameTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
           .UseInMemoryDatabase(databaseName: "Get_CompanyProfile")
           .Options;

            var profile = new CompanyProfile
            {
               Name = "Name"
            };

            CompanyProfile companyProfile;

            using (var context = new ApplicationDbContext(options))
            {
                context.CompaniesProfiles.Add(profile);
                context.SaveChanges();

                IProfileService service = new ProfileService(context);
                companyProfile = service.GetCompanyProfileWithName("Name");

            }

            Assert.Equal(profile.Name, companyProfile.Name);
            
            

        }

        [Fact]
        public void GetCompanyProfileWithUsernameTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
           .UseInMemoryDatabase(databaseName: "Get_CompanyProfile")
           .Options;

            var profile = new CompanyProfile
            {
                Account = new Account
                {
                    UserName = "username"
                }
            };

            CompanyProfile companyProfile;

            using (var context = new ApplicationDbContext(options))
            {
                context.CompaniesProfiles.Add(profile);
                context.SaveChanges();

                IProfileService service = new ProfileService(context);
                companyProfile = service.GetCompanyProfileWithUsername("username");

            }

            Assert.Equal(profile.Account.UserName, companyProfile.Account.UserName);

        }

        [Fact]
        public void RateTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
           .UseInMemoryDatabase(databaseName: "Get_CompanyProfile")
           .Options;

            var userProfile = new UserProfile();

            var profile = new CompanyProfile
            {
                Rating = new Rating
                {
                    AverageRating = 0,
                    RatingSum = 0,
                    CountOfVotes = 0,
                }
            };

            int countOfUsersRatings;
            using (var context = new ApplicationDbContext(options))
            {
                context.CompaniesProfiles.Add(profile);
                context.UserProfiles.Add(userProfile);
                context.SaveChanges();

                IProfileService service = new ProfileService(context);
                service.Rate(userProfile,profile,4);
                countOfUsersRatings = context.UsersRatings.Count();
            }

            Assert.Equal(1,profile.Rating.CountOfVotes);
            Assert.Equal(4, profile.Rating.AverageRating);
            Assert.Equal(4, profile.Rating.RatingSum);
            Assert.Equal(1, countOfUsersRatings);


        }
    }
}
