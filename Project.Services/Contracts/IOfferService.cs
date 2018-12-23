using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.Services.Contracts
{
    public interface IOfferService
    {
        void CreateOffer(decimal price, DateTime startDate, DateTime endDate, string comment, string jobId);
    }
}
