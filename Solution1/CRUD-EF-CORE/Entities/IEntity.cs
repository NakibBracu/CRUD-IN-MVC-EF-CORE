namespace CRUD_EF_CORE.Entities
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}
