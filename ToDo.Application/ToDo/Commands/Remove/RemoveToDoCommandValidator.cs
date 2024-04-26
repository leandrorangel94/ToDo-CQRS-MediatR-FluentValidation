using FluentValidation;

public class RemoveToDoCommandValidator : AbstractValidator<RemoveToDoCommand>
{
    public RemoveToDoCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}