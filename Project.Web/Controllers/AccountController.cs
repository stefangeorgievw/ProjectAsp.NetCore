using Microsoft.AspNetCore.Mvc;
using Project.Common;
using Project.Services.Contracts;
using Project.Web.Areas.User.ViewModels;
using Project.Web.ViewModels.Account;
using System.Threading.Tasks;

namespace Project.Web.Controllers
{
    public class AccountController : Controller
    {
       
        private IAccountService accountService;
        private ICategoryService categoryService;

        public AccountController(IAccountService accountService, ICategoryService categoryService)
        {
            this.accountService = accountService;
            this.categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (this.User.IsInRole(Constants.companyRoleName) || this.User.IsInRole(Constants.userRoleName))
            {
                return this.Redirect(Constants.homeUrl);
            }
            return View();
        }


        public IActionResult RegisterUser()
        {
            if (this.User.IsInRole(Constants.companyRoleName) || this.User.IsInRole(Constants.userRoleName))
            {
                return this.Redirect(Constants.homeUrl);
            }

            return this.View();
        }


        [HttpPost]
        public async Task<IActionResult> RegisterUser(RegisterAsUserInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

          await  this.accountService.CreateUser(model.Email,model.Username, model.FirstName, model.LastName,model.Password);

            return this.Redirect(Constants.loginUrl);


        }


        public IActionResult RegisterCompany()
        {
            if (this.User.IsInRole(Constants.companyRoleName) || this.User.IsInRole(Constants.userRoleName))
            {
                return this.Redirect(Constants.homeUrl);
            }

            var categoriesNames = this.categoryService.GetAllCategoriesNames();
            var model = new CategoryNameViewModel()
            {
                CategoriesNames = categoriesNames
            };
            ViewBag.Categories = model;

            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterCompany(RegisterAsCompanyInputModel model)
        {
            var areValidCategories = this.categoryService.AreCategoriesValid(model.CategoriesNames);

            if (!areValidCategories)
            {
                return this.View();
            }

            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            var categories = this.categoryService.GetCategoriesByName(model.CategoriesNames);

            await this.accountService.CreateCompany(model.Email, model.Username, model.Name, model.Description, model.Password,categories);

            return this.Redirect(Constants.loginUrl);

            
        }


        public IActionResult Login()
        {
            if (this.User.IsInRole(Constants.companyRoleName) || this.User.IsInRole(Constants.userRoleName))
            {
                return this.Redirect(Constants.homeUrl);
            }

            return this.View();
        }

        [HttpPost]
        public IActionResult Login(LoginInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

           var url = this.accountService.Login(model.Username, model.Password, model.RememberMe).Result;

            return this.Redirect(url);
           
           
            
        }

        [HttpGet]
        public IActionResult Logout()
        {
            this.accountService.Logout();

            return this.Redirect(Constants.homeUrl);
        }



    }
}
