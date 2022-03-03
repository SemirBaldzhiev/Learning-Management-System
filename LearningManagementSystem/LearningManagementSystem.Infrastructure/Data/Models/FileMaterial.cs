namespace LearningManagementSystem.Infrastructure.Data.Models
{
    public class FileMaterial
    {
        public int Id { get; set; }
        public string? FileName { get; set; }

        public byte[] FileData { get; set; }

        public int TopicId { get; set; }
        public Topic Topic { get; set; }
    }
}
