using Project.Models;
using Project.Services.Contracts;
using Project.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project.Services
{
    public class CategoryService : ICategoryService
    {
        private ApplicationDbContext context;

        public CategoryService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public bool IsCategoryValid(string categoryName)
        {
            var category = this.context.Categories.FirstOrDefault(x => x.Name == categoryName);
            if (category != null)
            {
                return true;
            }
            return false;
        }

        public IEnumerable<string> GetAllCategoriesNames()
        {
            return this.context.Categories.Select(x => x.Name).ToList();
        }
    }
}
