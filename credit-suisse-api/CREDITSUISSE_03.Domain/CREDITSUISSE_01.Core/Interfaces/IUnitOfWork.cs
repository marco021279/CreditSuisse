using System;
using System.Threading.Tasks;

namespace CREDITSUISSE_04.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> Commit();
    }
}