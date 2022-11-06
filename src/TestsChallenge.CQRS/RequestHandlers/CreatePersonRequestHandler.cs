using MediatR;
using TestsChallenge.Domain.Builders;
using TestsChallenge.Domain.Models;
using TestsChallenge.Domain.Requests;
using TestsChallenge.Domain.Responses;
using TestsChallenge.Shared.Repository;

namespace TestsChallenge.CQRS.RequestHandlers;

public class CreatePersonRequestHandler : IRequestHandler<CreatePersonRequest, CreatePersonRequestResponse>
{
    private readonly IBaseRepository<Person> _personRepository;
    
    public CreatePersonRequestHandler(IBaseRepository<Person> personRepository)
    {
        _personRepository = personRepository;
    }
    
    public async Task<CreatePersonRequestResponse> Handle(CreatePersonRequest request, CancellationToken cancellationToken)
    {
        var person = PersonBuilder.BuildPerson(request.CreatePersonDto);

        person.Validate();
        
        await _personRepository.Add(person);
        
        return new CreatePersonRequestResponse(person.Id);
    }
}