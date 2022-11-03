using Microsoft.EntityFrameworkCore;
using Reviews.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reviews.API.Context
{
    public class ReviewContext : DbContext
    {
        public ReviewContext()
        {

        }

        public ReviewContext( DbContextOptions<ReviewContext> options) : base(options)
        {
        }
        public DbSet<Reviewdetails> reviewdetails { get; set; }
    }
}
