using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobPortalApplication.Models
{
    public class JobDetailsDto
    {
        [Key]
        public int Id { get; set; }
        public string JobTitle { get; set; }
        [ForeignKey("EmployerDetails")]
        public int ComapnayId { get; set; }
        [ForeignKey("JobCategory")]
        public int CategoryId { get; set; }
        [ForeignKey("JobType")]
        public int JobTypeId { get; set; }
        public string VacancyNo { get; set; }
        public string JobLevel { get; set; }
        public string JobLocation { get; set; }
        public string OfferedSalary { get; set; }
        public DateTime DeadLine { get; set; }
        public string EducationLevel { get; set; }
        public string ExperienceRequired { get; set; }
        public string OtherSpecification { get; set; }
        public string JobWorkDescription { get; set; }

        public virtual EmployerDetails EmployerDetails { get; set; }
        public virtual JobCategory JobCategory { get; set; }
        public virtual JobType JobType { get; set; }
    }
}
