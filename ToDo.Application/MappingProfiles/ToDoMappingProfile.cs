using AutoMapper;
using ToDo.Application.ToDo.Commands.Create;
using ToDo.Application.ViewModel;

namespace ToDo.Application.MappingProfiles;
public class ToDoMappingProfile : Profile
{
    public ToDoMappingProfile()
    {
        CreateMap<CreateToDoCommand, ToDoItem>().ReverseMap();
        CreateMap<ToDoItem, ToDoViewModel>().ReverseMap();
    }
}
