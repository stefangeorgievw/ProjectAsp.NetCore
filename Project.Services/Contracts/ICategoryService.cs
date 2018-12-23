using Project.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Services.Contracts
{
    public interface ICategoryService
    {
        bool IsCategoryValid(string categoryName);

        IEnumerable<string> GetAllCategoriesNames();

        bool AreCategoriesValid(IEnumerable<string> categoriesNames);

        IEnumerable<Category> GetCategoriesByName(IEnumerable<string> categoriesNames);
    }
}
