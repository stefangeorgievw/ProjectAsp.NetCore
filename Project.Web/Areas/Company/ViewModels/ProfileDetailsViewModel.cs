using Project.Models;
using Project.Web.Areas.User.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Web.Areas.Company.ViewModels
{
    public class ProfileDetailsViewModel
    {
    

        public string Name { get; set; }

        public string Email { get; set; }

        public double RateDigit { get; set; }

        public Rating Rating { get; set; }

        public Account Account { get; set; }

        public string Categories { get; set; }

        public string Description { get; set; }
    }
}
