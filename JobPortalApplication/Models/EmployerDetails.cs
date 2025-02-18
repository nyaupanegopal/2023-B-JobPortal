using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobPortalApplication.Models
{
    public class EmployerDetails
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string PrimaryContactPerson { get; set; }
        public string Email { get; set; }
        public string? UserId { get; set; }
        
        public virtual IdentityUser IdentityUser { get; set; }
    }
}
