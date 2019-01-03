using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Models
{
    public class Offer
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string CompanyId { get; set; }
        public CompanyProfile Company { get; set; }

        public decimal Price { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Comment { get; set; }

        public string JobId { get; set; }
        public Job Job { get; set; }

        public DateTime DateOfCreation { get; set; } = DateTime.UtcNow;
    }
}
