using CRUD_EF_CORE.Entities;

namespace CRUD_EF_CORE.Models
{
    public interface IRepository<TEntity, TKey>
       where TEntity : class, IEntity<TKey>
       where TKey : IComparable
    {
        void Add(TEntity entity) { }

        void Update(TEntity entity) { }

        void Remove(TEntity entity) { }

        void Remove(TKey key) { }

        TEntity GetEntity(TKey key);

        TEntity this[TKey i] { get; set; }

        void ShowValuesOfEntity(TKey key) { }

        void Update()
        {
        }

        IList<TEntity> GetAll();

        void ShowAllDataFromA_Single_Table<TEntity>(IEnumerable<TEntity> entities);





    }
}
