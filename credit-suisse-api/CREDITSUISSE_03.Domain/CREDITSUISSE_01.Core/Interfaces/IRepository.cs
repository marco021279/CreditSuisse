using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CREDITSUISSE_04.Core.Interfaces {
    public interface IRepository<T> : IDisposable where T : class {
        Task Add (T obj);
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById (Guid id);
        void Update (T obj);
        void Remove (T obj);
    }
}