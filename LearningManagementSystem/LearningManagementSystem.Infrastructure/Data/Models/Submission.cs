using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningManagementSystem.Infrastructure.Data.Models
{
    public class Submission
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime SubmissionDate { get; set; }

        [Required]
        public string SubmissionStatus { get; set; }

        [Required]
        [MaxLength(30)]
        public string FileName { get; set; }

        [Required]
        public double Grade { get; set; }

        [Required]
        [MaxLength(200)]
        public string Comment { get; set; }

        [ForeignKey(nameof(Assignment))]
        public int AssignmentId { get; set; }
        public Assignment Assignment{ get; set; }
    }
}
