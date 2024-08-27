namespace ApiListaCompras.Repository
{
    public interface IRepository<TEntity>
    {
        Task Add(TEntity entity);

        Task Save();

        Task<IEnumerable<TEntity>> Get();

        Task<TEntity> GetById(int id);

        void Update(TEntity entity);

        void Delete(TEntity entity);
    }
}
