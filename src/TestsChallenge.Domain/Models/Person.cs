using FluentValidation;
using TestsChallenge.Domain.Models.Abstractions;
using TestsChallenge.Domain.Validators;
using TestsChallenge.Shared.Abstractions;

namespace TestsChallenge.Domain.Models;

public class Person : BaseModel, IValidatableEntity
{
    public string FullName { get; set; }
    public PersonDetail Details { get; set; }

    public Person(string fullName, PersonDetail details, DateTime? creationDate, Guid? id) : base(creationDate, id)
    {
        FullName = fullName;
        Details = details;
    }

    public void Validate()
    {
        var validationResult = new PersonValidator().Validate(this);

        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }
    }
}