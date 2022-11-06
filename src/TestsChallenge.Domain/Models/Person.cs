using FluentValidation.Results;
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

    public ValidationResult Validate()
    {
        return new PersonValidator().Validate(this);
    }
}