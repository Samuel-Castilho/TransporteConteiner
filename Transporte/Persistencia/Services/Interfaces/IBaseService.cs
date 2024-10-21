using Microsoft.Identity.Client.Kerberos;

namespace Transporte.Persistencia.Services.Interfaces
{
    public interface IBaseService<T>
    {
        Task<T> CreateAsync(T obj);
        Task<List<T>> GetAllAsync();
        Task<T> UpdateAsync(T obj);


        Task<T> GetByIdAsync<K>(K key);
        Task<bool> DeleteByIdAsync<K>(K key);
    }
}
