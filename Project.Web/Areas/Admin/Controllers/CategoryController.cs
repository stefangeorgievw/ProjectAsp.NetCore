using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.Services.Contracts;
using Project.Web.Areas.Admin.ViewModels;

namespace Project.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class CategoryController : Controller
    {
        private ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateCategoryInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View();
            }

            var isCategoryExists = this.categoryService.IsCategoryValid(model.CategoryName);
            if (isCategoryExists)
            {
                return this.View();
            }

            this.categoryService.CreateCategory(model.CategoryName);

            return this.Redirect("/");
        }
    }
}