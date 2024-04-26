using MediatR;
using ToDo.Application.ViewModel;

namespace ToDo.Application.ToDo.Queries.GetAll
{
    public class GetAllQuery : IRequest<IList<ToDoViewModel>>
    {
    }
}
