using Microsoft.EntityFrameworkCore;
using Project.Models;
using Project.Services.Contracts;
using Project.Web.Data;
using Xunit;

namespace Project.Services.Tests
{
    public class ContractServiceTests
    {
        [Fact]
        public void GetContractShouldReturnContractTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
           .UseInMemoryDatabase(databaseName: "Get_Contract")
           .Options;

            var job = new Job
            {
                Contract = new Contract
                {
                    Name = "contract"
                },
            };

            Contract contract;
            using (var context = new ApplicationDbContext(options))
            {
                context.Jobs.Add(job);
                context.SaveChanges();
                IContractService service = new ContractService(context);
               contract = service.GetContract(job);
               
            }

            Assert.Equal(job.Contract, contract);


        }

        [Fact]
        public void GetContractShouldReturnNullTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
           .UseInMemoryDatabase(databaseName: "Get_Contract_null")
           .Options;

            var job = new Job
            {
                
            };

            Contract contract;
            using (var context = new ApplicationDbContext(options))
            {
                context.Jobs.Add(job);
                context.SaveChanges();
                IContractService service = new ContractService(context);
                contract = service.GetContract(job);

            }

            Assert.Null(contract);


        }
    }
}
