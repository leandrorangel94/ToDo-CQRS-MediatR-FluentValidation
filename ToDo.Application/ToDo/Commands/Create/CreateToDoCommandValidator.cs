using FluentValidation;
using ToDo.Application.ToDo.Commands.Create;

public class CreateToDoCommandValidator : AbstractValidator<CreateToDoCommand>
{
    public CreateToDoCommandValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .MaximumLength(255)
            .WithMessage("Preenchimento do titulo é obrigatório");
    }
}