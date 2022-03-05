using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningManagementSystem.Infrastructure.Data.Models
{
    public class Assignment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(70)]
        public string Title { get; set; }

        public byte[] Attachment { get; set; }

        public DateTime DueDate { get; set; }
        
        [ForeignKey(nameof(Submission))]
        public int SubmissionId { get; set; }
        public Submission Submission { get; set; }

        [ForeignKey(nameof(Course))]
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
