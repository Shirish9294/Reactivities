using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Services.Interface
{
    public interface IActivitiesRepo
    {
        Task<List<Activity>>GetActivities();

        Task<Activity>GetActivity(Guid id);
    }
}