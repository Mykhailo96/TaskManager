using AutoMapper;
using TaskManager.Models;
using TaskManager.Models.Dto;

namespace TaskManager.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<ProjectTask, ProjectTaskDto>();
            Mapper.CreateMap<ProjectTaskDto, ProjectTask>();
        }
    }
}