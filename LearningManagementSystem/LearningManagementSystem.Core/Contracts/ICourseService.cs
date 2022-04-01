using LearningManagementSystem.Core.Models.Course;

namespace LearningManagementSystem.Core.Contracts
{
    public interface ICourseService
    {
        Task<int> CreateCourse(CreateCourseViewModel course);
        Task<CourseQueryViewModel> All();

        Task<DetailsViewModel> Details(int? id);

        Task Delete(int id);

        Task<bool> Edit(CourseViewModel model);

        Task<CourseViewModel> GetCourseById(int? id);

        Task<bool> Delete(int? id);

        Task<bool> Enroll(int courseId, string studentId);
    }
}
