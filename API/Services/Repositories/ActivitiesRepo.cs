using API.Services.Interface;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Services.Repositories
{

    public class ActivitiesRepo : IActivitiesRepo
    {
        private readonly DataContext _context;
        public ActivitiesRepo(DataContext context)
        {
            _context=context;
        }
        public async Task<List<Activity>>GetActivities()
        {
            return await _context.Activities.ToListAsync();
        }

        public async Task<Activity> GetActivity(Guid id)
        {
            return await _context.Activities.FindAsync(id);
        }
    }
}