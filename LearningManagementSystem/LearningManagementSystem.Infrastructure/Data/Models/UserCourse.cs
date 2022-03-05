using System.ComponentModel.DataAnnotations.Schema;

namespace LearningManagementSystem.Infrastructure.Data.Models
{
    public class UserCourse
    {
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public User User { get; set; }

        [ForeignKey(nameof(Course))]
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
