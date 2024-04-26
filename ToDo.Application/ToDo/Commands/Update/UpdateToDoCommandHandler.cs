using AutoMapper;
using FluentValidation;
using MediatR;
using ToDo.Application.ViewModel;
using ToDo.Domain.Repositorios;

public class UpdateToDoCommandHandler : IRequestHandler<UpdateToDoCommand, ToDoViewModel>
{
    private readonly IToDoRepositorio _todoRepositorio;
    private readonly IMapper _mapper;
    private readonly IValidator<UpdateToDoCommand> _validator;

    public UpdateToDoCommandHandler(IToDoRepositorio todoRepositorio, IMapper mapper, IValidator<UpdateToDoCommand> validator)
    {
        _todoRepositorio = todoRepositorio;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<ToDoViewModel> Handle(UpdateToDoCommand request, CancellationToken cancellationToken)
    {
        await _validator.ValidateAndThrowAsync(request, cancellationToken);

        var taskBanco = await _todoRepositorio.GetByIdAsync(request.Id);

        if (taskBanco == null)
            throw new ApplicationException("Id não encontrado");

        taskBanco.Title = request.Title;
        taskBanco.IsCompleted = request.IsCompleted;

        await _todoRepositorio.UpdateAsync(taskBanco);

        return _mapper.Map<ToDoViewModel>(taskBanco);
    }
}