using Microsoft.EntityFrameworkCore;
using Project.Models;
using Project.Services.Contracts;
using Project.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Services
{
    public class OfferService : IOfferService
    {

        private ApplicationDbContext context;

        public OfferService(ApplicationDbContext context)
        {
            this.context = context;

        }
        public void CreateOffer(decimal price, DateTime startDate, DateTime endDate, string comment, string jobId,
            string companyUsername)
        {
            var job = this.context.Jobs.FirstOrDefault(x => x.Id == jobId);

            var company = this.context.Users.Include(x=> x.CompanyProfile)
                .Select(x => x.CompanyProfile).FirstOrDefault(x => x.Account.UserName == companyUsername);

            
            

            var offer = new Offer
            {
                Price = price,
                StartDate = startDate,
                EndDate = endDate,
                Comment = comment,
                JobId = jobId,
                Job = job,
                Company = company,
                CompanyId = company.Id
            };

            

            this.context.Offers.Add(offer);
             context.SaveChanges();

        }

        public IEnumerable<Offer> GetJobOffers(string jobId)
        {
           return this.context.Offers.Where(x => x.JobId == jobId).Include(x=> x.Company);
        }
    }
}
