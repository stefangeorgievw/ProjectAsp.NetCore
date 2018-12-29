using Project.Models;
using System.Collections.Generic;

namespace Project.Web.Areas.User.ViewModels
{
    public class JobOffersViewModel
    {
        public IEnumerable<Offer> Offers { get; set; }
    }
}
