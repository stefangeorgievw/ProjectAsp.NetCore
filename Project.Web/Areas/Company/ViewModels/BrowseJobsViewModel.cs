using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Web.Areas.Company.ViewModels
{
    public class BrowseJobsViewModel
    {
       public  IEnumerable<Job> Jobs { get; set; }
    }
}
