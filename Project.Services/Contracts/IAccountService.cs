using Project.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.Services.Contracts
{
    public interface IAccountService
    {
        Task CreateUser(string email, string username, string firstName,
           string lastName, string password);


        Task CreateCompany(string email, string username, string name,
            string description, string password, IEnumerable<Category> categories);

        Task<string> Login(string username, string password, bool rememberMe);

        Task Logout();

        Task CreateRole(string roleName, Account user);
    }
}
