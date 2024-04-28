namespace CarAuctionSystem.Domain.Common;

public abstract class BaseEntity
{
    public Guid Id { get; set; }

    public static Guid CreateNewId()
    {
        return Guid.NewGuid();
    }

}
