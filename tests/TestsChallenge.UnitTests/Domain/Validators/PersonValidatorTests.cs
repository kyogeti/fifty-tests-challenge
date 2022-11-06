using System.Linq.Expressions;
using AutoFixture;
using FluentValidation.TestHelper;
using TestsChallenge.Domain.Models;
using TestsChallenge.Domain.Validators;
using Xunit;

namespace TestsChallenge.UnitTests.Domain.Validators;

public class PersonValidatorTests
{
    private readonly IFixture _fixture;
    private readonly PersonValidator _validator;

    public PersonValidatorTests()
    {
        _fixture = new Fixture();
        _validator = new PersonValidator();
    }
    
    [Fact]
    public void Validate_GivenEmptyFullName_ShouldHaveValidationErrorForFullName()
    {
        var person = BuildPerson<Person, string>(x => x.FullName, string.Empty);

        AssertValidationErrorFor(x=> x.FullName, person);
    }

    [Fact]
    public void Validate_GivenNullDetails_ShouldHaveValidationErrorForDetails()
    {
        var person = BuildPerson<Person, PersonDetail>(x => x.Details, null!);

        AssertValidationErrorFor(x=> x.Details, person);
    }

    [Fact]
    public void Validate_GivenValidFullNameAndDetails_ShouldNotHaveValidationError()
    {
        var person = BuildPerson<Person, string>(x => x.FullName, _fixture.Create<string>());
        person.Details = _fixture.Create<PersonDetail>();
        
        _validator.TestValidate(person).ShouldNotHaveAnyValidationErrors();
    }

    private void AssertValidationErrorFor<TProperty>(Expression<Func<Person, TProperty>> validationExpression,
        Person person)
    {
        _validator
            .TestValidate(person)
            .ShouldHaveValidationErrorFor(validationExpression);
    }

    private TPerson BuildPerson<TPerson, TProperty>(Expression<Func<TPerson, TProperty>> propertyPickerExpression,
        TProperty propertyValue)
    {
        return _fixture
            .Build<TPerson>()
            .With(propertyPickerExpression, propertyValue)
            .Create();
    }
}