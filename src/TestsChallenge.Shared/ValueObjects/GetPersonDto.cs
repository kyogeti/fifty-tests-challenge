namespace TestsChallenge.Shared.ValueObjects;

public record GetPersonDto(
    Guid Id,
    string Status,
    DateTime CreationDate,
    string FullName,
    string Document,
    string Genre,
    DateTime DateOfBirth,
    int AgeInYears
)
{
    public static int GetAgeInYears(DateTime dateOfBirth)
    {
        return DateTime.Now.Year - dateOfBirth.Year;
    }
};