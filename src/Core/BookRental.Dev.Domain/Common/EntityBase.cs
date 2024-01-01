namespace BookRental.Dev.Domain.Common;
public abstract class EntityBase
{
    protected EntityBase()
    {
        Id = Guid.NewGuid();
        CreateDate = DateTime.Now;
    }

    protected EntityBase(Guid id,DateTime updateTime)
    {
        Id = id;
        CreateDate = DateTime.Now;
        UpdateDate = updateTime;
    }

    public Guid Id { get; private set; }
    public DateTime CreateDate { get; private set; }
    public DateTime UpdateDate { get; set; }
}