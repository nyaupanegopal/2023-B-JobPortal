using System.ComponentModel.DataAnnotations;

namespace JobPortalApplication.Models
{
    public class JobDetailsDto
    {
        [Key]
        public int Id { get; set; }
        public string JobTitle { get; set; }
        public int ComapnayId { get; set; }
        public int CategoryId { get; set; }
        public int JobTypeId { get; set; }
        public string VacancyNo { get; set; }
        public string JobLevel { get; set; }
        public string JobLocation { get; set; }
        public string OfferedSalary { get; set; }
        public string DeadLine { get; set; }
        public string EducationLevel { get; set; }
        public string ExperienceRequired { get; set; }
        public string OtherSpecification { get; set; }
        public string JobWorkDescription { get; set; }
    }
}
