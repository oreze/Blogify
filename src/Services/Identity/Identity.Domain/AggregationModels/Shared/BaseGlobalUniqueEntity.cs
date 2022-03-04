namespace Identity.Domain.AggregationModels.Shared;

public class BaseGlobalUniqueEntity
{
    public Guid Id { get; private set; }
    public DateTime CreationDate { get; }

    public BaseGlobalUniqueEntity()
    {
        CreationDate = new DateTime();
    }
}