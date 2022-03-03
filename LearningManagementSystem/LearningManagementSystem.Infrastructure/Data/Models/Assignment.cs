namespace LearningManagementSystem.Infrastructure.Data.Models
{
    public class Assignment
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public byte[] Attachment { get; set; }
        public DateTime DueDate { get; set; }
        
        public int SubmissionId { get; set; }
        public Submission Submission { get; set; }

        // Course / CourseId 
    }
}
