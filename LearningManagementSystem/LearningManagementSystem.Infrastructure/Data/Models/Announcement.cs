namespace LearningManagementSystem.Infrastructure.Data.Models
{
    public class Announcement
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime LastUpdated { get; set; }

        //Course / CourseId
    }
}
