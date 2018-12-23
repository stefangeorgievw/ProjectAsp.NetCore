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

        public bool AreCategoriesValid(IEnumerable<string> categoriesNames)
        {
            var isValid = true;
            foreach (var categoryName in categoriesNames)
            {
                if (!IsCategoryValid(categoryName))
                {
                    isValid = false;
                    break;
                }
                 
            }
            return isValid;
        }

        public IEnumerable<string> GetAllCategoriesNames()
        {
            return this.context.Categories.Select(x => x.Name).ToList();
        }

        public IEnumerable<Category> GetCategoriesByName(IEnumerable<string> categoriesNames)
        {
            var categories = new List<Category>();
            foreach (var categoryName in categoriesNames)
            {
                var category = this.context.Categories.FirstOrDefault(x => x.Name == categoryName);
                categories.Add(category);
            }
            return categories;
        }
    }
}
