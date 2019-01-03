using System;

namespace Project.Models
{
    public class Contract
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string UserId { get; set; }
        public UserProfile User { get; set; }

        public string CompanyId { get; set; }
        public CompanyProfile Company { get; set; }

        public string JobId { get; set; }
        public Job Job { get; set; }

        public DateTime DateOfCreation { get; set; } = DateTime.UtcNow;
    }
}