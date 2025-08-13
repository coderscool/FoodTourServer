namespace Domain.Abstractions.Entities
{
    public interface IEntity
    {
        string Id { get; }
        bool IsDeleted { get; }
    }
}
