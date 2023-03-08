using API.Dtos;
using API.Services.Interface;
using AutoMapper;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Services.Repositories
{

    public class ActivitiesRepo : IActivitiesRepo
    {
        private readonly DataContext _context;
        private readonly IMapper _map;
        public ActivitiesRepo(DataContext context, IMapper map)
        {
            _context=context;
            _map=map;
        }

        public async Task<ActivityDto> CreateActivity(ActivityDto activityDto)
        {
            Activity activity = _map.Map<ActivityDto, Activity>(activityDto);
            _context.Activities.Add(activity);
            await _context.SaveChangesAsync();
            return _map.Map<Activity, ActivityDto>(activity);
        }

        public async Task<bool> DeleteActivity(Guid id)
        {
            Activity activity = await _context.Activities.FindAsync(id);
            if (activity != null)
            {
                _context.Remove(activity);
                await _context.SaveChangesAsync();
                _map.Map<ActivityDto>(activity);
                return true;
            }
            return false;
        }

        public async Task<UpdateActivityDto> EditActivity(Guid Id, UpdateActivityDto activityDto)
        {
            Activity activity = await _context.Activities.FindAsync(Id);
            if(activity!=null){
                _map.Map(activityDto, activity);
                await _context.SaveChangesAsync();
                return _map.Map<UpdateActivityDto>(activity);   
            }
            else{
                return null;
            }
        }

        public async Task<List<ActivityDto>>GetActivities()
        {
            List<Activity> activity = await _context.Activities.ToListAsync();
            return _map.Map<List<ActivityDto>>(activity);
        }

        public async Task<ActivityDto> GetActivity(Guid id)
        {
            Activity activity = await _context.Activities.FindAsync(id);
            return _map.Map<ActivityDto>(activity);
        }
    }
}