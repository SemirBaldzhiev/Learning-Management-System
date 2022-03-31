﻿using LearningManagementSystem.Core.Contracts;
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
                        Id = c.Id,
                        Title = c.Title,
                        Description = c.Description,
                        ImageUrl = c.ImageUrl
                    })
                    .ToListAsync()
            };


            return courses;
        }

        public async Task<DetailsViewModel> Details(int? id)
        {
            var course = await repo.GetByIdAsync<Course>(id);

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

            var latestAnnModel = course.Announcements
                .Select(a => new AnnouncementViewModel()
                {
                    Title = latestAnn.Title,
                    Content = latestAnn.Content,
                    LastUpdated = latestAnn.LastUpdated
                })
                .FirstOrDefault();

            var model = new DetailsViewModel()
            {
                Id = course.Id,
                Title = course.Title,
                Description = course.Description,
                LatestAnnouncement = latestAnnModel,
                Topics = topicsModel
            };

            return model;
        }

        public async Task Delete(int courseId)
        {
            await repo.DeleteAsync<Course>(courseId);
        }

        public async Task<bool> Edit(int id)
        {
            var course = await repo.GetByIdAsync<Course>(id);

            if (course == null)
            {
                return false;
            }

            repo.Update(course);

            await repo.SaveChangesAsync();

            return true;
        }



    }
}
