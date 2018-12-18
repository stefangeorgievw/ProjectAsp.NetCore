using System;
using System.Collections.Generic;

namespace Project.Models
{
    public class Category
    {
        public Category()
        {
            this.Jobs = new HashSet<Job>();
        }
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string Name { get; set; }

         public IEnumerable<Job> Jobs { get; set; }
    }
}