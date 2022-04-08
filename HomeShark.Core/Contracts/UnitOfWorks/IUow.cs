using System;
using System.Threading.Tasks;

namespace HomeShark.Core.Contracts.UnitOfWorks
{
    public interface IUow : IDisposable
    {
        Task SaveAsync();
    }
}
