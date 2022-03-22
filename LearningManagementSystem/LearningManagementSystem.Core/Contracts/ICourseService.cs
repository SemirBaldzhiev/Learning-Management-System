using LearningManagementSystem.Core.Models.Course;

namespace LearningManagementSystem.Core.Contracts
{
    public interface ICourseService
    {
        Task<int> CreateCourse(CreateCourseViewModel course);
        Task<CourseQueryViewModel> All();
    }
}
