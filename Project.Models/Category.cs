using System;

namespace Project.Models
{
    public class Category
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string Name { get; set; }


    }
}