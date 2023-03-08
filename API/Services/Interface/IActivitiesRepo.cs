using API.Dtos;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Services.Interface
{
    public interface IActivitiesRepo
    {
        Task<List<ActivityDto>>GetActivities();

        Task<ActivityDto>GetActivity(Guid id);

        Task<ActivityDto> CreateActivity(ActivityDto activity);

        Task<UpdateActivityDto> EditActivity(Guid id, UpdateActivityDto activity);

        Task<bool>DeleteActivity(Guid id);
    }
}