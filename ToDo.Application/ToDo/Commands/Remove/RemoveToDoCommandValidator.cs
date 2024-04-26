using FluentValidation;

public class RemoveToDoCommandValidator : AbstractValidator<RemoveToDoCommand>
{
    public RemoveToDoCommandValidator()
    {
        RuleLevelCascadeMode = CascadeMode.Stop;

        RuleFor(x => x.Id)
            .NotNull()
            .WithMessage("O id é um campo obrigatório.")
            .GreaterThan(0)
            .WithMessage("Id inválido informado.");
    }
}