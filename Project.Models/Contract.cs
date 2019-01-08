using System;

namespace Project.Models
{
    public class Contract
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string Name { get; set; }

        public byte[] Document { get; set; }

        public DateTime DateOfCreation { get; set; } = DateTime.UtcNow;
    }
}