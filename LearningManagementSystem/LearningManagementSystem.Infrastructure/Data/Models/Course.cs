using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningManagementSystem.Infrastructure.Data.Models
{
    public class Course
    {
        public Course()
        {
            Assignments = new HashSet<Assignment>();
            Discussions = new HashSet<Discussion>();
            Topics = new HashSet<Topic>();
            Announcements = new HashSet<Announcement>();
            Students = new HashSet<StudentCourse>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(60)]
        public string Title { get; set; }

        [Required]
        [MaxLength(150)]
        public string Description { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [ForeignKey(nameof(Teacher))]
        public string TeacherId { get; set; }
        public ApplicationUser Teacher { get; set; }

        public ICollection<Assignment> Assignments { get; set; }

        public ICollection<Discussion> Discussions { get; set; }

        public ICollection<Topic> Topics { get; set; }

        public ICollection<StudentCourse> Students { get; set; }

        public ICollection<Announcement> Announcements { get; set; }
    }
}
