using Microsoft.AspNetCore.Http;
using Project.Models;

namespace Project.Services.Contracts
{
    public interface IContractService
    {
        void UploadContract(IFormFile file, Job job);

        Contract GetContract(Job job);
    }
}
