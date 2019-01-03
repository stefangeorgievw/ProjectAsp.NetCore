using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Models
{
    public class Rating
    {
        public Rating()
        {
            this.VotedUsers = new HashSet<UserRating>(); 
        }
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public double RatingSum { get; set; } = 0;

        public double CountOfVotes { get; set; } 

        public double AverageRating { get; set; }

        public HashSet<UserRating> VotedUsers { get; set; } 

    }
}
