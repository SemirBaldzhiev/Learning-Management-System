using LearningManagementSystem.Core.Contracts;
using LearningManagementSystem.Core.Models.Announcement;
using LearningManagementSystem.Core.Models.Course;
using LearningManagementSystem.Core.Models.Material;
using LearningManagementSystem.Core.Models.Topic;
using LearningManagementSystem.Infrastructure.Data.Models;
using LearningManagementSystem.Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
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
                Courses = await repo.All<Course>()
                    .Select(c => new CourseViewModel
                    {
                        Title = c.Title,
                        Description = c.Description,
                        ImageUrl = c.ImageUrl
                    })
                    .ToListAsync()
            };


            return courses;
        }

        public async Task<DetailsViewModel> Details(int corseId)
        {
            var course = await repo.GetByIdAsync<Course>(corseId);

            var latestAnn = course.Announcements.LastOrDefault();

            var topics = course.Topics.ToList();

            var topicsModel = topics
                .Select(t => new TopicViewModel()
                {
                    Title = t.Title,
                    FileMaterials = t.FileMaterials
                        .Select(f => new FileMaterialViewModel()
                        {
                            FileName = f.FileName,
                            FileData = f.FileData
                        }),
                    TextMaterials = t.TextMaterials
                        .Select(tm => new TextMaterialViewModel()
                        {
                            Content = tm.Content,
                        })
                })
                .ToList();

            var model = new DetailsViewModel()
            {
                Title = course.Title,
                Description = course.Description,
                LatestAnnouncement = new AnnouncementViewModel()
                {
                    Title = latestAnn.Title,
                    Content = latestAnn.Content,
                    LastUpdated = latestAnn.LastUpdated
                },
                Topics = topicsModel
            };

            return model;
        }
    }
}
