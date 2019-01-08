using Project.Models;
using Project.Models.Enums;
using System.Collections.Generic;

namespace Project.Services.Contracts
{
    public interface IJobService
    {
        void CreateJob(string title, string description, string address,string username,
            string categoryName);

        IEnumerable<Job> GetJobs(string username, JobStatus status);

        Job GetJob(string id);

        IEnumerable<Job> GetWaitingForCompanyJobsWithSameCategories(string companyUsername);

        bool AcceptOffer(Offer offer);

        IEnumerable<Job> GetCompanyJobs(string username, JobStatus status);

        void FinishJobs(string username);

        void FinishCompanyJobs(string username);
    }
}
