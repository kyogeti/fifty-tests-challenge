using TestsChallenge.Shared.Abstractions;

namespace TestsChallenge.Domain.Models.Abstractions;

public abstract class BaseModel : IBaseModel
{
    public Guid Id { get; }
    public DateTime CreationDate { get; }
    public bool Active { get; private set; }

    protected BaseModel(DateTime? creationDate, Guid? id)
    {
        CreationDate = creationDate ?? DateTime.Now;
        Id = id ?? Guid.NewGuid();
        Active = true;
    }

    protected virtual void Deactivate()
    {
        Active = false;
    }

    protected virtual void Activate()
    {
        Active = true;
    }
}