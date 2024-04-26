using FluentValidation;
using MediatR;
using ToDo.Domain.Repositorios;

public class RemoveToDoCommandHandler : IRequestHandler<RemoveToDoCommand>
{
    private readonly IToDoRepositorio _todoRepositorio;
    private readonly IValidator<RemoveToDoCommand> _validator;

    public RemoveToDoCommandHandler(IToDoRepositorio todoRepositorio, IValidator<RemoveToDoCommand> validator)
    {
        _todoRepositorio = todoRepositorio;
        _validator = validator;
    }

    public async Task Handle(RemoveToDoCommand request, CancellationToken cancellationToken)
    {
        await _validator.ValidateAndThrowAsync(request, cancellationToken);
        await _todoRepositorio.DeleteAsync(request.Id);
    }
}