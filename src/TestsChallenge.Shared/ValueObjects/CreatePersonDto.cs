using TestsChallenge.Shared.Enumerations;

namespace TestsChallenge.Shared.ValueObjects;

public record CreatePersonDto(
    string FullName,
    string Document,
    DateTime DateOfBirth,
    PersonGenre Genre);