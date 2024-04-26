using FluentValidation;
using ToDo.Application.ToDo.Commands.Create;

public class CreateToDoCommandValidator : AbstractValidator<CreateToDoCommand>
{
    public CreateToDoCommandValidator()
    {
        RuleLevelCascadeMode = CascadeMode.Stop;

        RuleFor(x => x.Title)
            .NotEmpty()
            .WithMessage("Preenchimento do titulo é obrigatório.")
            .MaximumLength(255)
            .WithMessage("Excedeu o limite de caracteres permitidos para o título.");
    }
}