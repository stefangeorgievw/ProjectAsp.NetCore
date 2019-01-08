using Microsoft.AspNetCore.Http;
using Project.Common;
using Project.Models;
using Project.Services.Contracts;
using Project.Web.Data;
using System.IO;
using System.Linq;

namespace Project.Services
{
    public class ContractService:IContractService
    {
        private ApplicationDbContext context;

        public ContractService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void UploadContract(IFormFile file, Job job)
        {
            if (file.Length > 0)
            {
                byte[] fileBytes;
                using (var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    fileBytes = ms.ToArray();
                    
                }

                var contract = new Contract
                {
                    Document = fileBytes,
                    Name = Constants.contractName,
                };

                context.Contracts.Add(contract);
                job.Contract = contract;
                context.SaveChanges();
            }


        }

        public Contract GetContract(Job job)
        {
      
            return job.Contract;
        }
    }
}
