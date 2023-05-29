using HomeShark.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HomeShark.Core.Dtos.Requests;
using HomeShark.Services.Contracts;

namespace HomeShark.Services.Models
{
    public interface IAgentService : IService<Agent>, IDisposable
    {
        Task<List<Agent>> GetAllByContainsNameAsync(string name);

        Task<Agent> AddAsync(AgentRequest agentRequest);

        Task<Agent> UpdateAsync(Agent agent);

        Task<Agent> SetInactiveAsync(Agent agent);
    }
}
