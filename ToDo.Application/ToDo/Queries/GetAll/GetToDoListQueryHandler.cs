using AutoMapper;
using MediatR;
using ToDo.Application.ToDo.Queries.GetAll;
using ToDo.Application.ViewModel;
using ToDo.Domain.Repositorios;

public class GetToDoListQueryHandler : IRequestHandler<GetAllQuery, IList<ToDoViewModel>>
{
    private readonly IToDoRepositorio _toDoRepository;
    private readonly IMapper _mapper;

    public GetToDoListQueryHandler(IToDoRepositorio toDoRepository, IMapper mapper)
    {
        _toDoRepository = toDoRepository;
        _mapper = mapper;
    }

    public async Task<IList<ToDoViewModel>> Handle(GetAllQuery request, CancellationToken cancellationToken)
    {
        var toDoItems = await _toDoRepository.GetAllAsync();
        var toDoViewModels = _mapper.Map<IList<ToDoViewModel>>(toDoItems);

        return toDoViewModels;
    }
}