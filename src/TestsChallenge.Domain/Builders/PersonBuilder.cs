using TestsChallenge.Domain.Models;
using TestsChallenge.Shared.ValueObjects;

namespace TestsChallenge.Domain.Builders;

public static class PersonBuilder
{
    public static Person BuildPerson(CreatePersonDto createPersonDto)
    {
        var personId = Guid.NewGuid();
        var details = new PersonDetail(personId, createPersonDto.Document, createPersonDto.DateOfBirth,
            createPersonDto.Genre, DateTime.UtcNow, Guid.NewGuid());
        
        return new Person(createPersonDto.FullName, details, DateTime.UtcNow, personId);
    }
}