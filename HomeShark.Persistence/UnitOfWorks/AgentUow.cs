using HomeShark.Core.Contracts.Repositories;
using HomeShark.Core.Contracts.UnitOfWorks;
using HomeShark.Core.Models;

namespace HomeShark.Persistence.UnitOfWorks
{
    public sealed class AgentUow : GenericUow, IAgentUow
    {
        public AgentUow(HomeSharkContext context, IRepository<Agent> agents) : base(context) => Agents = agents;

        public IRepository<Agent> Agents { get; }
    }
}
