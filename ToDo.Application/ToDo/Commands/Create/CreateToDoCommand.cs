using MediatR;
using ToDo.Application.ViewModel;

namespace ToDo.Application.ToDo.Commands.Create
{
    public class CreateToDoCommand : IRequest<ToDoViewModel>
    {
        public required string Title { get; set; }
    }
}