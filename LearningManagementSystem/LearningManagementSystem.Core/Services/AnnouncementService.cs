using LearningManagementSystem.Core.Contracts;
using LearningManagementSystem.Core.Models.Announcement;
using LearningManagementSystem.Infrastructure.Data.Models;
using LearningManagementSystem.Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningManagementSystem.Core.Services
{
    public class AnnouncementService : IAnnouncementService
    {
        private readonly IApplicationDbRepository repo;

        public AnnouncementService(IApplicationDbRepository _repo)
        {
            repo = _repo;
        }

        public async Task<int> Create(CreateAnnouncementViewModel model)
        {
            var announcement = new Announcement()
            {
                Title = model.Title,
                Content = model.Content,
                LastUpdated = DateTime.UtcNow
            };

            await repo.AddAsync(announcement);
            await repo.SaveChangesAsync();

            return announcement.Id;
        }


    }
}
