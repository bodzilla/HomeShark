using HomeShark.Core.Contracts.Repositories;
using HomeShark.Core.Models;

namespace HomeShark.Core.Contracts.UnitOfWorks
{
    public interface IAgentUow : IUow
    {
        IRepository<Agent> Agents { get; }
    }
}
