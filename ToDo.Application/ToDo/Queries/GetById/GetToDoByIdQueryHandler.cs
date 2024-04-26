using AutoMapper;
using MediatR;
using ToDo.Application.ToDo.Queries.GetById;
using ToDo.Application.ViewModel;
using ToDo.Domain.Entities;
using ToDo.Domain.Repositorios;

public class GetToDoByIdQueryHandler : IRequestHandler<GetToDoByIdQuery, ToDoViewModel>
{
    private readonly IToDoRepositorio _toDoRepository;
    private readonly IMapper _mapper;

    public GetToDoByIdQueryHandler(IToDoRepositorio toDoRepository, IMapper mapper)
    {
        _toDoRepository = toDoRepository;
        _mapper = mapper;
    }

    public async Task<ToDoViewModel> Handle(GetToDoByIdQuery request, CancellationToken cancellationToken)
    {
        var todoItem = await _toDoRepository.GetByIdAsync(request.Id);
        var todoItemViewModel = _mapper.Map<ToDoViewModel>(todoItem);

        return todoItemViewModel;
    }
}