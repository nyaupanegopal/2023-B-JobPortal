using System.ComponentModel.DataAnnotations;

namespace JobPortalApplication.Models
{
    public class JobDetailsDto
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public string Municipality { get; set; }
    }
}
