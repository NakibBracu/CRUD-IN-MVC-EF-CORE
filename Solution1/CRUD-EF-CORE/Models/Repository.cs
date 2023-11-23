using CRUD_EF_CORE.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRUD_EF_CORE.Models
{
    public abstract class Repository<TEntity, TKey>
     : IRepository<TEntity, TKey> where TKey : IComparable
     where TEntity : class, IEntity<TKey>
    {
        protected DbContext _dbContext;
        protected DbSet<TEntity> _dbSet;


        public Repository(DbContext context)
        {

            _dbContext = context;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public TEntity this[TKey i]
        {
            get { return _dbContext.Set<TEntity>().Find(i); }
            set { _dbContext.Set<TEntity>().Update(value); _dbContext.SaveChanges(); }
        }

        public TEntity GetEntity(TKey key)
        {
            return _dbSet.Find(key);
        }



        public virtual void Add(TEntity entity)
        {
            _dbSet.Add(entity);
            _dbContext.SaveChanges();
        }
        public virtual void Remove(TKey id)
        {
            var entityToDelete = _dbSet.Find(id);
            Remove(entityToDelete);
        }

        public virtual void Remove(TEntity entityToDelete)
        {
            if (_dbContext.Entry(entityToDelete).State == EntityState.Detached)
            {
                _dbSet.Attach(entityToDelete);
            }
            _dbSet.Remove(entityToDelete);
            _dbContext.SaveChanges();
        }

        public virtual void ShowValuesOfEntity(TKey key)
        {
            var entity = _dbSet.Find(key);
            if (entity != null)
            {
                Console.WriteLine("entity of " + entity.GetType().Name);
                foreach (var en in entity.GetType().GetProperties())
                {
                    Console.WriteLine(en.Name + " " + en.GetValue(entity));
                }
            }
        }
        public virtual void Update()
        {
            _dbContext.SaveChanges(true);
        }

        public virtual IList<TEntity> GetAll()
        {
            IQueryable<TEntity> query = _dbSet;
            return query.ToList();
        }

        public virtual void ShowAllDataFromA_Single_Table<TEntity>(IEnumerable<TEntity> entities)
        {
            var properties = typeof(TEntity).GetProperties();
            Console.WriteLine("Entities of " + typeof(TEntity).Name + " Table" + "\n");
            foreach (var entity in entities)
            {
                foreach (var property in properties)
                {
                    var columnName = property.Name;
                    var value = property.GetValue(entity);

                    Console.WriteLine($"{columnName}: {value}");
                }

                Console.WriteLine(); // Separate entities with an empty line
            }
        }

    }
}
