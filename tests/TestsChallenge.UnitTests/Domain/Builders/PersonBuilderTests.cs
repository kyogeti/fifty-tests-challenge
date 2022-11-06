using AutoFixture;
using FluentAssertions;
using TestsChallenge.Domain.Builders;
using TestsChallenge.Domain.Models;
using TestsChallenge.Shared.Enumerations;
using TestsChallenge.Shared.ValueObjects;
using Xunit;

namespace TestsChallenge.UnitTests.Domain.Builders;

public class PersonBuilderTests
{
    [Theory]
    [MemberData(nameof(BuildPerson))]
    public void BuildPerson_GivenCreatePersonDto_ShouldBuildAsExpected(Guid personId, PersonDetail personDetail)
    {
        var expectedPerson = new Person("Xpto", personDetail, DateTime.Now, personId);
        var createPersonDto = new CreatePersonDto(expectedPerson.FullName, expectedPerson.Details.Document,
            expectedPerson.Details.DateOfBirth, expectedPerson.Details.Genre);

        var builtPerson = PersonBuilder.BuildPerson(createPersonDto);

        builtPerson
            .Should()
            .Match<Person>(x =>
                x.FullName == expectedPerson.FullName &&
                x.Details.Document == expectedPerson.Details.Document &&
                x.Details.DateOfBirth == expectedPerson.Details.DateOfBirth &&
                x.Details.Genre == expectedPerson.Details.Genre);
    }

    [Theory]
    [MemberData(nameof(BuildPerson))]
    public void BuildPerson_GivenCreatePersonDtoWithBadDateOfBirthConstruction_ShouldNotMatchExpected(Guid personId,
        PersonDetail personDetail)
    {
        var expectedPerson = new Person("Xpto", personDetail, DateTime.Now, personId);
        var createPersonDto = new CreatePersonDto(expectedPerson.FullName, expectedPerson.Details.Document,
            expectedPerson.Details.DateOfBirth.AddDays(1), expectedPerson.Details.Genre);

        var builtPerson = PersonBuilder.BuildPerson(createPersonDto);

        builtPerson.Details.DateOfBirth.Should().NotBe(expectedPerson.Details.DateOfBirth);
    }

    [Theory]
    [MemberData(nameof(BuildPerson))]
    public void BuildPerson_GivenCreatePersonDtoWithBadDocumentConstruction_ShouldNotMatchExpected(Guid personId,
        PersonDetail personDetail)
    {
        var expectedPerson = new Person("Xpto", personDetail, DateTime.Now, personId);
        var createPersonDto = new CreatePersonDto(expectedPerson.FullName,
            expectedPerson.Details.Document + "salt",
            expectedPerson.Details.DateOfBirth, expectedPerson.Details.Genre);

        var builtPerson = PersonBuilder.BuildPerson(createPersonDto);

        builtPerson.Details.Document.Should().NotBe(expectedPerson.Details.Document);
    }

    [Theory]
    [MemberData(nameof(BuildPerson))]
    public void BuildPerson_GivenCreatePersonDtoWithBadGenreConstruction_ShouldNotMatchExpected(Guid personId,
        PersonDetail personDetail)
    {
        var expectedPerson = new Person("Xpto", personDetail, DateTime.Now, personId);
        var createPersonDto = new CreatePersonDto(expectedPerson.FullName,
            expectedPerson.Details.Document,
            expectedPerson.Details.DateOfBirth, BuildGenre(expectedPerson.Details.Genre));

        var builtPerson = PersonBuilder.BuildPerson(createPersonDto);

        builtPerson.Details.Genre.Should().NotBe(expectedPerson.Details.Genre);
    }

    private PersonGenre BuildGenre(PersonGenre detailsGenre)
    {
        switch (detailsGenre)
        {
            case PersonGenre.Male:
                return PersonGenre.Female;
            case PersonGenre.Female:
                return PersonGenre.Male;
            case PersonGenre.NonBinary:
                return PersonGenre.Female;
            default:
                return PersonGenre.Female;
        }
    }

    private static IEnumerable<object[]> BuildPerson()
    {
        var fixture = new Fixture();
        foreach (var genre in Enum.GetValues(typeof(PersonGenre)))
        {
            var personId = Guid.NewGuid();
            var details = new PersonDetail(personId, fixture.Create<string>(),
                fixture.Create<DateTime>(), (PersonGenre)genre);
            yield return new object[]
            {
                personId, details
            };
        }
    }
}