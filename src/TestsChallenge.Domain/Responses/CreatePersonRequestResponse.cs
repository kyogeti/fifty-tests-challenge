namespace TestsChallenge.Domain.Responses;

public class CreatePersonRequestResponse
{
    public Guid PersonId { get; }

    public CreatePersonRequestResponse(Guid personId)
    {
        PersonId = personId;
    }
}