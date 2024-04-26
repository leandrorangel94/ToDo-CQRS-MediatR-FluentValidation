using MediatR;
using ToDo.Application.ViewModel;

namespace ToDo.Application.ToDo.Queries.GetById
{
    public class GetToDoByIdQuery : IRequest<ToDoViewModel>
    {
        public int Id { get; set; }
    }
}