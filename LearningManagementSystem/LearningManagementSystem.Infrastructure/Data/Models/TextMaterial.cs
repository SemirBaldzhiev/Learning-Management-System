namespace LearningManagementSystem.Infrastructure.Data.Models
{
    public class TextMaterial
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public DateTime LastUpdated { get; set; }

        public int TopicId { get; set; }
        public Topic Topic { get; set; }
    }
}
