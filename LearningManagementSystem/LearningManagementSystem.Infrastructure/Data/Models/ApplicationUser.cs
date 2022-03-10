using LearningManagementSystem.Infrastructure.Data.Models.Enums;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace LearningManagementSystem.Infrastructure.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            Trainings = new HashSet<Course>();
            Courses = new HashSet<StudentCourse>();

        }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public Gender Gender { get; set; }

        public ICollection<Course> Trainings { get; set; }

        public ICollection<StudentCourse> Courses { get; set; }
    }
}
