using Project.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Web.Areas.Company.ViewModels
{
    public class RatingInputModel
    {
        [Required]
        [Range(0,1)]
        public double RateDigit { get; set; }
    }
}
