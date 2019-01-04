using Microsoft.EntityFrameworkCore;
using Project.Models;
using Project.Services.Contracts;
using Project.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Project.Services.Tests
{
    public class OfferServiceTests
    {
        [Fact]
        public void GetJobOffersTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
           .UseInMemoryDatabase(databaseName: "Create_Offer")
           .Options;

            var job = new Job { Id = "jobid" };

            var account = new Account
            {
                UserName = "username",
                CompanyProfile = new CompanyProfile
                {
                    Id = "id"
                }
            };

            int result;
            using (var context = new ApplicationDbContext(options))
            {
                context.Jobs.Add(job);
                context.Users.Add(account);
                context.SaveChanges();

                IOfferService service = new OfferService(context);
                service.CreateOffer(12,DateTime.Now,DateTime.Now,"comment","jobid","username");
                result = context.Offers.Count();
            }

            Assert.Equal(1, result);

        }

        [Fact]
        public void GetOfferShouldReturnOfferTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
           .UseInMemoryDatabase(databaseName: "Get_Offer")
           .Options;

            var offer = new Offer { Id = "offerid"};



            Offer result;
            using (var context = new ApplicationDbContext(options))
            {
                context.Offers.Add(offer);
                context.SaveChanges();

                IOfferService service = new OfferService(context);
                 result = service.GetOffer("offerid");
                
            }

            Assert.Equal(result.Id, offer.Id);

        }

        [Fact]
        public void GetOfferShouldReturnNullTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
           .UseInMemoryDatabase(databaseName: "Get_Offer_Null")
           .Options;

            var offer = new Offer { Id = "offerid" };



            Offer result;
            using (var context = new ApplicationDbContext(options))
            {
                context.Offers.Add(offer);
                context.SaveChanges();

                IOfferService service = new OfferService(context);
                result = service.GetOffer("false");

            }

            Assert.Null(result);

        }

        [Fact]
        public void CreateOfferTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
           .UseInMemoryDatabase(databaseName: "Get_Offers")
           .Options;

            var offers = new List<Offer>
            {
                new Offer{ JobId = "jobid"},
                new Offer{JobId = "jobid"}
            };

            int result;
            using (var context = new ApplicationDbContext(options))
            {
                context.Offers.AddRange(offers);
                context.SaveChanges();

                IOfferService service = new OfferService(context);
                var jobs = service.GetJobOffers("jobid");
                result = jobs.Count();
            }

            Assert.Equal(2, result);

        }
    }
}
