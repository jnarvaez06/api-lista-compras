namespace ApiListaCompras.Services
{
    public interface ICommonService<T>
    {
        Task<IEnumerable<T>> Get();
        Task<T> GetById(int id);
        Task<T> Add(T generalDTO);
        Task<T> Update(int id, T generalDTO);
        Task<T> Delete(int id);

    }
}
