using AutoMapper;
using FluentValidation;
using MediatR;
using ToDo.Application.ToDo.Commands.Create;
using ToDo.Application.ViewModel;
using ToDo.Domain.Repositorios;

public class CreateToDoCommandHandler : IRequestHandler<CreateToDoCommand, ToDoViewModel>
{
    private readonly IToDoRepositorio _todoRepositorio;
    private readonly IMapper _mapper;
    private IValidator<CreateToDoCommand> _validator;

    public CreateToDoCommandHandler(IToDoRepositorio todoRepositorio, IMapper mapper, IValidator<CreateToDoCommand> validator)
    {
        _todoRepositorio = todoRepositorio;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<ToDoViewModel> Handle(CreateToDoCommand request, CancellationToken cancellationToken)
    {
        await _validator.ValidateAndThrowAsync(request, cancellationToken);

        var task = _mapper.Map<ToDoItem>(request);
        await _todoRepositorio.AddAsync(task);

        return _mapper.Map<ToDoViewModel>(task);
    }
}