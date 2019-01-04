using Microsoft.EntityFrameworkCore;
using Project.Models;
using Project.Models.Enums;
using Project.Services.Contracts;
using Project.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Project.Services.Tests
{
    public class JobServiceTests
    {
        [Fact]
        public void CreateJobTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
           .UseInMemoryDatabase(databaseName: "Create_Job")
           .Options;

            int result;
            var user = new Account
            {
                UserName = "username",
                UserProfile = new UserProfile
                {
                    Id = Guid.NewGuid().ToString(),

                },
            };

            using (var context = new ApplicationDbContext(options))
            {
                IJobService service = new JobService(context);
                context.Categories.Add(new Category { Name = "categoryName",Id = "id" });
                context.Users.Add(user);
                context.SaveChanges();

                service.CreateJob("title", "description", "address", "username", "categoryName");
                result = context.Jobs.Count();
            }

            Assert.Equal(1, result);
            


        }

        [Fact]
        public void GetJobsTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
           .UseInMemoryDatabase(databaseName: "Get_Jobs")
           .Options;

            int result;
            var user = new Account
            {
                UserName = "username",
                UserProfile = new UserProfile
                {
                    Id = Guid.NewGuid().ToString(),

                },
            };

            using (var context = new ApplicationDbContext(options))
            {
                IJobService service = new JobService(context);
                context.Categories.Add(new Category { Name = "categoryName", Id = "id" });
                context.Users.Add(user);
                context.SaveChanges();
                service.CreateJob("title", "description", "address", "username", "categoryName");
               var jobs= service.GetJobs("username",JobStatus.WaitingForCompany);
                result = jobs.Count();
            }

            Assert.Equal(1, result);



        }

        [Fact]
        public void GetJobShouldReturnJobTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
           .UseInMemoryDatabase(databaseName: "Get_Job")
           .Options;

            Job result;
          

            using (var context = new ApplicationDbContext(options))
            {
                IJobService service = new JobService(context);
                context.Jobs.Add(new Job { Id = "id1" });
                context.SaveChanges();
                result = service.GetJob("id1");
            }

            Assert.NotNull(result);



        }

        [Fact]
        public void GetJobShouldReturnNullTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
           .UseInMemoryDatabase(databaseName: "Get_Job_Null")
           .Options;

            Job result;


            using (var context = new ApplicationDbContext(options))
            {
                IJobService service = new JobService(context);
                context.Jobs.Add(new Job { Id = "id1" });
                context.SaveChanges();
                result = service.GetJob("null");
            }

            Assert.Null(result);



        }

        [Fact]
        public void GetWaitingForCompanyJobsWithSameCategoriesTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
           .UseInMemoryDatabase(databaseName: "Get_Waiting_Job")
           .Options;

            IEnumerable<Job> result;

            var category = new Category
            {
                Name = "Category"
            };

            var company = new Account
            {
                UserName = "company",
            };

           var profile = new CompanyProfile
            {
                Categories = new List<Category> { category },
                Account = company,

            };

            company.CompanyProfile = profile;
            using (var context = new ApplicationDbContext(options))
            {
                IJobService service = new JobService(context);
                context.Categories.Add(category);
                context.Users.Add(company);
                context.CompaniesProfiles.Add(profile);
                context.SaveChanges();
                context.Jobs.Add(new Job { Id = "id1",Category = category,Status = JobStatus.WaitingForCompany });
                context.Jobs.Add(new Job { Id = "id2", Category = category, Status = JobStatus.WaitingForCompany });
                context.SaveChanges();
                result = service.GetWaitingForCompanyJobsWithSameCategories("company");
            }

            Assert.Equal(2,result.Count());



        }

        [Fact]
        public void AcceptOfferShouldReturnTrueTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
          .UseInMemoryDatabase(databaseName: "Accept_Offer")
          .Options;

            bool result;
            var company = new CompanyProfile
            {
                Id = "companyId"
            };

            var offer = new Offer
            {
                JobId = "jobid",
                Price = 12m,
                Company = company,
                CompanyId = company.Id,

            };

            var job = new Job { Id = "jobid" };

            using (var context = new ApplicationDbContext(options))
            {
                IJobService service = new JobService(context);
                context.Jobs.Add(job);
                context.CompaniesProfiles.Add(company);
                context.Offers.Add(offer);
                context.SaveChanges();

              result = service.AcceptOffer(offer);
            }

            Assert.True(result);


        }

        [Fact]
        public void AcceptOfferShouldReturnFalseTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
          .UseInMemoryDatabase(databaseName: "Accept_Offer_False")
          .Options;

            bool result;
            var company = new CompanyProfile
            {
                Id = "companyId"
            };

            var offer = new Offer
            {
                JobId = "false",
                Price = 12m,
                Company = company,
                CompanyId = company.Id,

            };

            var job = new Job { Id = "jobid" };

            using (var context = new ApplicationDbContext(options))
            {
                IJobService service = new JobService(context);
                context.Jobs.Add(job);
                context.CompaniesProfiles.Add(company);
                context.Offers.Add(offer);
                context.SaveChanges();

                result = service.AcceptOffer(offer);
            }

            Assert.False(result);


        }
    }
}
