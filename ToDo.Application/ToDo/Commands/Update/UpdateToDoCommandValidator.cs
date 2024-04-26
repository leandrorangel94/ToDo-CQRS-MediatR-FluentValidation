using FluentValidation;

public class UpdateToDoCommandValidator : AbstractValidator<UpdateToDoCommand>
{
    public UpdateToDoCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0);

        RuleFor(x => x.Title)
            .NotEmpty()
            .MaximumLength(255);
    }
}