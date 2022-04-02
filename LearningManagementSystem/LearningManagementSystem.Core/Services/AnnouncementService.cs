using LearningManagementSystem.Core.Contracts;
using LearningManagementSystem.Core.Models.Announcement;
using LearningManagementSystem.Infrastructure.Data.Models;
using LearningManagementSystem.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public async Task<AllAnnouncementsViewModel> All()
        {
            var announcements = new AllAnnouncementsViewModel()
            {
                Announcements = await repo.All<Announcement>()
                    .Select(a => new AnnouncementViewModel
                    {
                        Id = a.Id,
                        Title = a.Title,
                        LastUpdated = a.LastUpdated
                    })
                    .ToListAsync()
            };


            return announcements;
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

        public async Task<bool> Delete(int? id)
        {
            if (id == null)
            {
                return false;
            }

            await repo.DeleteAsync<Announcement>(id);

            return true;
        }

        public async Task<bool> Edit(EditAnnouncementViewModel model)
        {
            var announcement = await repo.GetByIdAsync<Announcement>(model.Id);

            announcement.Title = model.Title;
            announcement.Content = model.Content;
            announcement.LastUpdated = DateTime.UtcNow; 

            if (model == null)
            {
                return false;
            }

            repo.Update(announcement);

            await repo.SaveChangesAsync();

            return true;
        }
    }
}
