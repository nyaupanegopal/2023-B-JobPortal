using JobPortalApplication.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JobPortalApplication.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> 
            options)
            : base(options)
        {
            
        }
        public DbSet<JobDetailsDto> JobDetails { get; set; }
    }
}