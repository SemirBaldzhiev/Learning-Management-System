using LearningManagementSystem.Infrastructure.Data.Common;

namespace LearningManagementSystem.Infrastructure.Data.Repositories
{
    public class ApplicationDbRepository : Repository, IApplicationDbRepository
    {
        public ApplicationDbRepository(LearningSystemDbContext context)
        {
            this.Context = context;
        }
    }
}
