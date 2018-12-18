using Project.Models;
using Project.Web.Data;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using Project.Services.Contracts;
using Project.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace Project.Services
{
    public class JobService:IJobService
    {
        private ApplicationDbContext context;

        public JobService(ApplicationDbContext context)
        {
            this.context = context;
        
        }

        public void CreateJob(string title, string description, decimal maxPrice, string address, string username,
             string categoryName)
        {
            var user = this.context.Users.Include(x=> x.UserProfile).FirstOrDefault(x=> x.UserName == username);
            var category = this.context.Categories.FirstOrDefault(x => x.Name == categoryName);

            var job = new Job()
            {
                Title = title,
                Description = description,
                Price = maxPrice,
                Address = address,
                User = user.UserProfile,
                UserId = user.UserProfile.Id,
                Category = category,
                CategoryId = category.Id,
            };

            this.context.Jobs.Add(job);
            this.context.SaveChanges();
        }

        public IEnumerable<Job> GetJobs(string username,JobStatus status)
        {
            var jobs = this.context.Jobs.Where(x => x.User.Account.UserName == username).Where(x => x.Status == status).ToList();

            return jobs;
        }

        public Job GetJob(string id)
        {
            var job = this.context.Jobs.Include(x=> x.Company).Include(x=> x.User).Include(x=> x.User.Account).FirstOrDefault(x => x.Id == id);

            return job;
        }
    }
}
