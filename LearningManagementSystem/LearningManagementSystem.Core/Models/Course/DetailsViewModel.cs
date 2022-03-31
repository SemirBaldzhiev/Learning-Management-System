using LearningManagementSystem.Core.Models.Announcement;
using LearningManagementSystem.Core.Models.Topic;

namespace LearningManagementSystem.Core.Models.Course
{
    public class DetailsViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public AnnouncementViewModel LatestAnnouncement { get; set; }

        public IEnumerable<TopicViewModel> Topics { get; set; }
    }
}
