using TestsChallenge.Domain.Models.Abstractions;
using TestsChallenge.Shared.Enumerations;

namespace TestsChallenge.Domain.Models;

public class PersonDetail : BaseModel
{
    public Guid PersonId { get; set; }
    public string Document { get; set; }
    public DateTime DateOfBirth { get; set; }
    public PersonGenre Genre { get; set; }

    public PersonDetail(Guid personId, string document, DateTime dateOfBirth, PersonGenre genre, 
        DateTime? creationDate = null!, Guid? id = null!) 
        : base(creationDate, id)
    {
        PersonId = personId;
        Document = document;
        DateOfBirth = dateOfBirth;
        Genre = genre;
    }
}