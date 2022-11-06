using FluentValidation;
using TestsChallenge.Domain.Models;

namespace TestsChallenge.Domain.Validators;

public class PersonValidator : AbstractValidator<Person>
{
    public PersonValidator()
    {
        RuleFor(x => x.FullName)
            .NotEmpty();
        RuleFor(x => x.Details)
            .NotNull();
    }
}