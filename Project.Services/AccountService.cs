using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Project.Models;
using Project.Services.Contracts;
using Project.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Services
{
    public class AccountService:IAccountService
    {
        private const string UserRoleName = "User";
        private const string CompanyRoleName = "Company";


        private ApplicationDbContext context;
        private UserManager<Account> userManager;
        private SignInManager<Account> signInManager;
        private RoleManager<IdentityRole> roleManager;

        public AccountService(ApplicationDbContext context, UserManager<Account> userManager,
            SignInManager<Account> signInManager
            , RoleManager<IdentityRole> roleManager)
        {
            this.context = context;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager; 
        }

        public async Task CreateUser(string email, string username, string firstName, 
            string lastName, string password)
        {
            var userProfile = new UserProfile()
            {
                FirstName = firstName,
                LastName = lastName
            };

            var user = new Account
            {
                Email = email,
                UserName = username,
                UserProfile = userProfile,
                UserProfileId = userProfile.Id,   
            };
            

            var result = await userManager.CreateAsync(user, password);
            
            if (result.Succeeded)
            {
                await CreateRole(UserRoleName, user);

                userProfile.AccountId = user.Id;
                userProfile.Account = user;
                context.SaveChanges();

                

                
            }
        }

        public async Task<string> Login(string username, string password,bool rememberMe)
        {
            // To enable password failures to trigger account lockout, set lockoutOnFailure: true
            var result = await signInManager.PasswordSignInAsync(username, password, rememberMe, lockoutOnFailure: true);
            var returnUrl = string.Empty;
           
            if (result.Succeeded)
            {
                var user = this.context.Users.First(x => x.UserName == username);
            
                var roles = await userManager.GetRolesAsync(user);
                if (roles.Contains("Admin"))
                {
                    returnUrl = "/";
                }
                else if (roles.Contains("Company"))
                {
                    returnUrl = "/Company/Job/Browse";
                }
                else 
                {
                    returnUrl = "~/User/Job/MyJobs";
                }

                return returnUrl;
            }
            
            else
            {
                returnUrl = "/Account/Login";
                return returnUrl;
            }
        }

        public async Task CreateCompany(string email, string username, string name,
            string description, string password, IEnumerable<Category> categories)
        {
            var rating = new Rating();

            var companyProfile = new CompanyProfile
            {
                Name = name,
                Description = description,
                Categories = categories,
                Rating = rating
            };

           

            var user = new Project.Models.Account
            {
                Email = email,
                UserName = username,
                CompanyProfile = companyProfile,
                CompanyProfileId = companyProfile.Id,
                
                
               
            };
            var result = await userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                await CreateRole(CompanyRoleName, user);

                companyProfile.AccountId = user.Id;
                companyProfile.Account = user;
                context.SaveChanges();

                


            }
        }

        public  async Task CreateRole(string roleName, Account user)
        {
            bool roleExists = await roleManager.RoleExistsAsync(roleName);
            if (!roleExists)
            {  
                var role = new IdentityRole();
                role.Name = roleName;
               var createRole = await roleManager.CreateAsync(role);
                if (createRole.Succeeded)
                {
                    var result = await userManager.AddToRoleAsync(user, roleName);
                }
                    
                
            }
             var results = await userManager.AddToRoleAsync(user, roleName);



        }


        public async Task Logout()
        {

            await this.signInManager.SignOutAsync();

            


        }

        public string GetAccountId(string username)
        {
            var account = this.context.Users.FirstOrDefault(x => x.UserName == username);

            return account.Id;
        }

        
    }
}
