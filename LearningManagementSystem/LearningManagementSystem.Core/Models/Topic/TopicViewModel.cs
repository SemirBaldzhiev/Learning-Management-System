using LearningManagementSystem.Core.Models.Material;

namespace LearningManagementSystem.Core.Models.Topic
{
    public class TopicViewModel
    {
        public string Title { get; set; }

        public IEnumerable<FileMaterialViewModel> FileMaterials { get; set; }
        public IEnumerable<TextMaterialViewModel> TextMaterials { get; set; }

    }
}
