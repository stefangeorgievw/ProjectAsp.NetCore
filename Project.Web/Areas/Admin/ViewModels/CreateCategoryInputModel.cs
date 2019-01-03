using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Web.Areas.Admin.ViewModels
{
    public class CreateCategoryInputModel
    {
        [Required]
        public string CategoryName { get; set; }
    }
}
