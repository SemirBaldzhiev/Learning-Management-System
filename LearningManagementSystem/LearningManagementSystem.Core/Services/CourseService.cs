using LearningManagementSystem.Core.Contracts;
using LearningManagementSystem.Core.Models.Course;
using LearningManagementSystem.Infrastructure.Data.Models;
using LearningManagementSystem.Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace LearningManagementSystem.Core.Services
{
    public class CourseService : ICourseService
    {
        private readonly IApplicationDbRepository repo;
        private readonly IHttpContextAccessor httpContextAccessor;

        public CourseService(IApplicationDbRepository _repo, IHttpContextAccessor _httpContextAccessor)
        {
            repo = _repo;
            httpContextAccessor = _httpContextAccessor; 
        }

        public async Task<int> CreateCourse(CreateCourseViewModel course)
        {
            var courseData = new Course
            {
                Title = course.Title,
                Description = course.Description,
                ImageUrl = "https://www.onehappydog.com/wp-content/uploads/online-course-img.png",
                TeacherId = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)
            };

            await repo.AddAsync(courseData);
            await repo.SaveChangesAsync();

            return courseData.Id;
        }

        public async Task<CourseQueryViewModel> All()
        {
            var courses = new CourseQueryViewModel
            {
                Courses = repo.All<Course>()
                    .Select(c => new CourseViewModel
                    {
                        Title = c.Title,
                        Description = c.Description,
                        ImageUrl = c.ImageUrl
                    })
                    .ToList()
            };


            return courses;
        }
    }
}
