using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Web.Areas.Company.ViewModels
{
    public class CreateOfferInputModel
    {

        public string JobId { get; set; }

        [Required]
        [Range(0.1,double.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        public string Comment { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{yyyy-MM-dd}")]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{yyyy-MM-dd}")]
        public DateTime EndDate { get; set; }

        
    }
}
