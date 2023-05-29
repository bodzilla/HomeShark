using HomeShark.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HomeShark.Core.Dtos.Requests;

namespace HomeShark.Services.Models
{
    public interface IAgentService : IDisposable
    {
        Task<List<Agent>> GetAllAsync();

        Task<Agent> GetByIdAsync(int id);

        Task<List<Agent>> GetAllByContainsNameAsync(string name);

        Task<Agent> AddAsync(AgentRequest agentRequest);

        Task<Agent> UpdateAsync(Agent agent);

        Task<Agent> SetInactiveAsync(Agent agent);
    }
}
