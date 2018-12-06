using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Project.Models;
using Project.Services.Contracts;
using Project.Web.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.Services
{
    public class AccountService:IAccountService
    {
        private const string UserRoleName = "User";
        private const string CompanyRoleName = "Company";


        private ApplicationDbContext context;
        private UserManager<Account> _userManager;
        private SignInManager<Account> _signInManager;
        private RoleManager<IdentityRole> _roleManager;

        public AccountService(ApplicationDbContext context, UserManager<Account> userManager,
            SignInManager<Account> signInManager
            , RoleManager<IdentityRole> roleManager)
        {
            this.context = context;
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._roleManager = roleManager; 
        }

        public async Task CreateUser(string email, string username, string firstName, 
            string lastName, string password)
        {
            var user = new Project.Models.Account
            {
                Email = email,
                UserName = username,
                UserProfile = new UserProfile
                {
                    FirstName = firstName,
                    LastName = lastName
                }
            };
            var result = await _userManager.CreateAsync(user, password);
            
            if (result.Succeeded)
            {
                await CreateRole(UserRoleName, user);

                await _signInManager.SignInAsync(user, isPersistent: false);

                
            }
        }

        public async Task<bool> Login(string username, string password,bool rememberMe)
        {
            // To enable password failures to trigger account lockout, set lockoutOnFailure: true
            var result = await _signInManager.PasswordSignInAsync(username, password, rememberMe, lockoutOnFailure: true);
            if (result.Succeeded)
            {
                return true;
            }
            
            else
            {
                return false;
            }
        }

        public async Task CreateCompany(string email, string username, string name,
            string description, string password)
        {
            var user = new Project.Models.Account
            {
                Email = email,
                UserName = username,
                CompanyProfile = new CompanyProfile
                {
                    Name = name,
                    Description = description
                }
            };
            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                await CreateRole(CompanyRoleName, user);

                await _signInManager.SignInAsync(user, isPersistent: false);


            }
        }

        public  async Task CreateRole(string roleName, Account user)
        {
            bool roleExists = await _roleManager.RoleExistsAsync(roleName);
            if (!roleExists)
            {  
                var role = new IdentityRole();
                role.Name = roleName;
               var createRole = await _roleManager.CreateAsync(role);
                if (createRole.Succeeded)
                {
                    var result = await _userManager.AddToRoleAsync(user, roleName);
                }
                    
                
            }
             var results = await _userManager.AddToRoleAsync(user, roleName);



        }


        public async Task Logout()
        {

            await this._signInManager.SignOutAsync();

            


        }
    }
}
