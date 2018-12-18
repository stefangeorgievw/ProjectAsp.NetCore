using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Web.Areas.User.ViewModels
{
    public class CreateJobInputModel
    {
        [Required]
        [MinLength(5)]
        public string Title { get; set; }

        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal MaximumPrice { get; set; }

        [Required]
        [MinLength(20)]
        public string Description { get; set; }

        [Required]
        [MinLength(8)]
        public string Address { get; set; }

        [Required]
        public string CategoryName { get; set; }
    }
}
