using Microsoft.EntityFrameworkCore;
using Transporte.Persistencia.Context;
using Transporte.Persistencia.Services.Interfaces;

namespace Transporte.Persistencia.Services
{
    public class BaseService<T> : IBaseService<T> where T : class
    {
        protected TransporteContext _db;

        public BaseService(TransporteContext db)
        {
            _db = db;
        }

        public async Task<T> CreateAsync(T obj)
        {
            _db.Add(obj);
            await _db.SaveChangesAsync();

            return obj;
        }

        public async Task<bool> DeleteByIdAsync<K>(K key)
        {
            T obj = await _db.Set<T>().FindAsync(key);
            _db.Remove(obj);
            int alterado = await _db.SaveChangesAsync();

            return alterado > 0;
        }

        public async Task<List<T>> GetAllAsync()
        {
            List<T> list = await _db.Set<T>().ToListAsync();

            return list;
        }

        public async Task<T> GetByIdAsync<K>(K key)
        {
            T obj = await _db.Set<T>().FindAsync(key);

            return obj;
        }

        public async Task<T> UpdateAsync(T obj)
        {
            _db.Update(obj);
            int alterado = await _db.SaveChangesAsync();
            return obj;
        }
    }
}
