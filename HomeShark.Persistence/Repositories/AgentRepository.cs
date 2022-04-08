using HomeShark.Core.Models;

namespace HomeShark.Persistence.Repositories
{
    public sealed class AgentRepository : GenericRepository<Agent>
    {
        public AgentRepository(HomeSharkContext context) : base(context)
        {
        }
    }
}
