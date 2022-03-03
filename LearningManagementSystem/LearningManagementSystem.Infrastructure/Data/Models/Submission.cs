namespace LearningManagementSystem.Infrastructure.Data.Models
{
    public class Submission
    {
        public int Id { get; set; }
        public DateTime SubmissionDate { get; set; }
        public string SubmissionStatus { get; set; }
        public string FileName { get; set; }
        public double Grade { get; set; }
        public string Comment { get; set; }

        // Assignment / AssignmentId 
    }
}
