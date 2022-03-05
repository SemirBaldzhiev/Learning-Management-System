using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningManagementSystem.Infrastructure.Data.Models
{
    public class Topic
    {
        public Topic()
        {
            TextMaterials = new HashSet<TextMaterial>();
            FileMaterials = new HashSet<FileMaterial>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(60)]
        public string Title { get; set; }

        [ForeignKey(nameof(Course))]
        public int CourseId { get; set; }
        public Course Course { get; set; }

        public ICollection<TextMaterial> TextMaterials { get; set; }

        public ICollection<FileMaterial> FileMaterials { get; set; }
    }
}
