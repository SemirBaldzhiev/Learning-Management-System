using LearningManagementSystem.Core.Models.Announcement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningManagementSystem.Core.Contracts
{
    public interface IAnnouncementService
    {
        Task<int> Create(CreateAnnouncementViewModel model);

        Task<bool> Edit(EditAnnouncementViewModel model);

        Task<bool> Delete(int? id);

        Task<AllAnnouncementsViewModel> All();
    }
}
