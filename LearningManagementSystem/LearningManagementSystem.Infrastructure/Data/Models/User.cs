using LearningManagementSystem.Infrastructure.Data.Models.Enums;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace LearningManagementSystem.Infrastructure.Data.Models
{
    public class User : IdentityUser
    {
        public User()
        {
            Trainings = new HashSet<Course>();
            Courses = new HashSet<UserCourse>();

        }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public Gender Gender { get; set; }

        public ICollection<Course> Trainings { get; set; }

        public ICollection<UserCourse> Courses { get; set; }
    }
}
