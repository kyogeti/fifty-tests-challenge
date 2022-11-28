using FluentValidation.Results;

namespace TestsChallenge.Shared.Abstractions;

public interface IValidatableEntity
{
    void Validate();
}