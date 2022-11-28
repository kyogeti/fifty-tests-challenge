using AutoFixture;
using FluentAssertions;
using FluentValidation;
using Moq;
using TestsChallenge.CQRS.RequestHandlers;
using TestsChallenge.Domain.Models;
using TestsChallenge.Domain.Requests;
using TestsChallenge.Domain.Responses;
using TestsChallenge.Shared.Enumerations;
using TestsChallenge.Shared.Repository;
using TestsChallenge.Shared.ValueObjects;
using Xunit;

namespace TestsChallenge.UnitTests.CQRS.RequestHandlers;

public class CreatePersonRequestHandlerTests
{
    private readonly IFixture _fixture;
    private readonly Mock<IBaseRepository<Person>> _personRepositoryMock;
    private readonly CreatePersonRequestHandler _handler; 

    public CreatePersonRequestHandlerTests()
    {
        _fixture = new Fixture();
        _personRepositoryMock = new Mock<IBaseRepository<Person>>();
        _handler = new CreatePersonRequestHandler(_personRepositoryMock.Object);
    }

    [Fact]
    public async Task Handle_GivenInvalidPerson_ShouldThrowValidationException()
    {
        var dto = new CreatePersonDto(string.Empty, _fixture.Create<string>(), DateTime.Now, PersonGenre.Male);
        var request = new CreatePersonRequest(dto);

        Func<Task> action = async () => await _handler.Handle(request, CancellationToken.None);

        await action.Should().ThrowAsync<ValidationException>();
    }

    [Fact]
    public async Task Handle_GivenValidPerson_ShouldAddToRepository()
    {
        var dto = new CreatePersonDto(_fixture.Create<string>(), _fixture.Create<string>(), DateTime.Now, PersonGenre.Male);
        var request = new CreatePersonRequest(dto);

        await _handler.Handle(request, CancellationToken.None);
        
        _personRepositoryMock.Verify(x=> x.Add(It.IsAny<Person>()), Times.Once);
    }

    [Fact]
    public async Task Handle_GivenValidPerson_ShouldReturnAsExpected()
    {
        var dto = new CreatePersonDto(_fixture.Create<string>(), _fixture.Create<string>(), DateTime.Now, PersonGenre.Male);
        var request = new CreatePersonRequest(dto);

        var result = await _handler.Handle(request, CancellationToken.None);

        result.PersonId.Should().NotBeEmpty();
    }

}