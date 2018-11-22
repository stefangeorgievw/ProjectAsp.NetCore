using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Models.Interfaces
{
    public interface IProfile
    {
        string Id { get; set; }

        ICollection<Job> Jobs { get; set; }

       ICollection<Contract> Contracts { get; set; }
    }
}
