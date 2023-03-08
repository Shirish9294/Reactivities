using API.Dtos;
using AutoMapper;
using Domain;

namespace API
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ActivityDto, Activity>().ReverseMap();
                config.CreateMap<Activity, UpdateActivityDto>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}