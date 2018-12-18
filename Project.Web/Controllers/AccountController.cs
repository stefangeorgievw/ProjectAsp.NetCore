using Microsoft.AspNetCore.Mvc;
using Project.Services.Contracts;
using Project.Web.ViewModels.Account;
using System.Threading.Tasks;

namespace Project.Web.Controllers
{
    public class AccountController : Controller
    {
        private static string loginUrl = "/Account/Login";
        private static string homeUrl = "/Home/Index";
        private IAccountService accountService;

        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult RegisterUser()
        {
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

            return this.Redirect(loginUrl);


        }


        public IActionResult RegisterCompany()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterCompany(RegisterAsCompanyInputModel model)
        {

            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            await this.accountService.CreateCompany(model.Email, model.Username, model.Name, model.Description, model.Password);

            return this.Redirect(loginUrl);

            
        }


        public IActionResult Login()
        {
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

            return this.Redirect(homeUrl);
        }



    }
}
