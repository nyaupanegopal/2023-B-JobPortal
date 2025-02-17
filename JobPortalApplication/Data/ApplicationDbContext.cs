using JobPortalApplication.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JobPortalApplication.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> 
            options)
            : base(options)
        {
            
        }
        public DbSet<JobDetailsDto> JobDetails { get; set; }
        public DbSet<EmployerDetails> EmployerDetails { get; set; }
        public DbSet<JobCategory> JobCategory { get; set; }
        public DbSet<JobType> JobType { get; set; }
        public DbSet<EducationalQualification> EducationalQualification { get; set; }
    }
}