using Project.Models;
using System;
using System.Collections.Generic;

namespace Project.Services.Contracts
{
    public interface IOfferService
    {
        void CreateOffer(decimal price, DateTime startDate, DateTime endDate, string comment, string jobId,
            string companyUsername);

        IEnumerable<Offer> GetJobOffers(string jobId);

        Offer GetOffer(string offerId);
    }
}
