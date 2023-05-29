using HomeShark.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HomeShark.Core.Dtos.Requests;

namespace HomeShark.Core.Contracts.Services
{
    public interface IAgentService : IService<Agent, AddAgentRequest, UpdateAgentRequest>, IDisposable
    {
        Task<List<Agent>> GetAllByContainsNameAsync(string name);
    }
}
