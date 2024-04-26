using FluentValidation;

public class UpdateToDoCommandValidator : AbstractValidator<UpdateToDoCommand>
{
    public UpdateToDoCommandValidator()
    {
        RuleLevelCascadeMode = CascadeMode.Stop;

        RuleFor(x => x.Id)
            .NotNull()
            .WithMessage("O id é um campo obrigatório.")
            .GreaterThan(0)
            .WithMessage("Id inválido informado.");

        RuleFor(x => x.Title)
            .NotEmpty()
            .WithMessage("Preenchimento do titulo é obrigatório.")
            .MaximumLength(255)
            .WithMessage("Excedeu o limite de caracteres permitidos para o título.");
    }
}