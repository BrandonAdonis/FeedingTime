using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using FeedingTime.Models;

namespace FeedingTime.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<FeedingTime.Models.Animal> Animal { get; set; }
        public DbSet<FeedingTime.Models.StaffMember> StaffMembers { get; set; }
        public DbSet<FeedingTime.Models.Food> Food { get; set; }
    }
}
