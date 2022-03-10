using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningManagementSystem.Infrastructure.Data.Models
{
    public class Assignment
    {
        public Assignment()
        {
            Submissions = new HashSet<Submission>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(70)]
        public string Title { get; set; }

        public byte[] Attachment { get; set; }

        public DateTime DueDate { get; set; }

        [ForeignKey(nameof(Course))]
        public int CourseId { get; set; }
        public Course Course { get; set; }

        public ICollection<Submission> Submissions { get; set; }
    }
}
