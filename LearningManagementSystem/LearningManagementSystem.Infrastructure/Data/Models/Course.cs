using System.ComponentModel.DataAnnotations;

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

        public ICollection<Assignment> Assignments { get; set; }

        public ICollection<Discussion> Discussions { get; set; }

        public ICollection<Topic> Topics { get; set; }


        //public ICollection<Discussion> Students { get; set; }

        public ICollection<Announcement> Announcements { get; set; }
    }
}
