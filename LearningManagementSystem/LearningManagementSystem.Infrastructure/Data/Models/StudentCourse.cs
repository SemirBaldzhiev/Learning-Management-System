using System.ComponentModel.DataAnnotations.Schema;

namespace LearningManagementSystem.Infrastructure.Data.Models
{
    public class StudentCourse
    {
        [ForeignKey(nameof(Student))]
        public string StudentId { get; set; }
        public ApplicationUser Student { get; set; }

        [ForeignKey(nameof(Course))]
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
