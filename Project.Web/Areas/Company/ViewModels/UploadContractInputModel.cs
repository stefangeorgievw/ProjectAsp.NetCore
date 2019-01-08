using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Project.Web.Areas.Company.ViewModels
{
    public class UploadContractInputModel
    {
        [Required]
        public IFormFile ContractFile { get; set; }

        [Required]
        public string JobId { get; set; }
    }
}
