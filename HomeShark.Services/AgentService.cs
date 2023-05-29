using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HomeShark.Core.Dtos.Requests;
using HomeShark.Core.Models;
using HomeShark.Persistence;
using HomeShark.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HomeShark.Services
{
    public sealed class AgentService : IAgentService
    {
        private readonly ILogger<AgentService> _logger;
        private readonly HomeSharkContext _context;
        private readonly IMapper _mapper;

        public AgentService(ILogger<AgentService> logger, HomeSharkContext context, IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }

        public void Dispose() => _context?.Dispose();

        public async Task<List<Agent>> GetAllAsync()
        {
            try
            {
                return await _context.Agents.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error getting all {nameof(AgentService)}");
                throw;
            }
        }

        public async Task<Agent> GetByIdAsync(int id)
        {
            try
            {
                if (id <= 0) throw new ArgumentOutOfRangeException(nameof(id), id, $"{nameof(id)} must be greater than 0");

                return await _context.Agents.FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error getting {nameof(Agent)} by ID");
                throw;
            }
        }

        public async Task<List<Agent>> GetAllByContainsNameAsync(string name)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name), $"{nameof(name)} cannot be null or empty");

                return await _context.Agents
                    .Where(x => EF.Functions.Like(x.Name.ToLower(), $"%{name.ToLower()}%"))
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error getting {nameof(Agent)} by {nameof(Agent.Name)}");
                throw;
            }
        }

        public async Task<Agent> AddAsync(AgentRequest agentRequest)
        {
            try
            {
                if (agentRequest == null) throw new ArgumentNullException(nameof(agentRequest), $"{nameof(agentRequest)} cannot be null");

                var agent = _mapper.Map<Agent>(agentRequest);
                await _context.Agents.AddAsync(agent);
                await _context.SaveChangesAsync();
                return agent;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error adding {nameof(agentRequest)}");
                throw;
            }
        }

        public async Task<Agent> UpdateAsync(Agent agent)
        {
            try
            {
                if (agent == null) throw new ArgumentNullException(nameof(agent), $"{nameof(agent)} cannot be null");

                agent.EntityModified = DateTime.Now;
                _context.Agents.Update(agent);
                await _context.SaveChangesAsync();
                return agent;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error updating {nameof(agent)}");
                throw;
            }
        }

        public async Task<Agent> SetInactiveAsync(Agent agent)
        {
            try
            {
                if (agent == null) throw new ArgumentNullException(nameof(agent), $"{nameof(agent)} cannot be null");

                agent.EntityActive = false;
                return await UpdateAsync(agent);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error setting inactive {nameof(agent)}");
                throw;
            }
        }
    }
}
