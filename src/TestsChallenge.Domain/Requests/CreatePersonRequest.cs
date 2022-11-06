using MediatR;
using TestsChallenge.Domain.Responses;
using TestsChallenge.Shared.ValueObjects;

namespace TestsChallenge.Domain.Requests;

public class CreatePersonRequest : IRequest<CreatePersonRequestResponse>
{
    public CreatePersonDto CreatePersonDto { get; }

    public CreatePersonRequest(CreatePersonDto createPersonDto)
    {
        CreatePersonDto = createPersonDto;
    }
}