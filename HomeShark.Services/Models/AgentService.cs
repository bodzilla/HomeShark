using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HomeShark.Core.Dtos.Requests;
using HomeShark.Core.Models;
using HomeShark.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HomeShark.Services.Models
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
            List<Agent> agents;

            try
            {
                agents = await _context.Agents.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error getting all {nameof(AgentService)}");
                throw;
            }

            return agents;
        }

        public async Task<Agent> GetByIdAsync(int id)
        {
            Agent agent;

            try
            {
                if (id <= 0) throw new ArgumentOutOfRangeException(nameof(id), id, $"{nameof(id)} must be greater than 0");

                agent = await _context.Agents.FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error getting {nameof(agent)} by ID");
                throw;
            }

            return agent;
        }

        public async Task<List<Agent>> GetAllByContainsNameAsync(string name)
        {
            List<Agent> agents;

            try
            {
                if (String.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name), $"{nameof(name)} cannot be null or empty");

                agents = await _context.Agents
                    .Where(x => EF.Functions.Like(x.Name.ToLower(), $"%{name.ToLower()}%"))
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error getting {nameof(Agent)} by {nameof(Agent.Name)}");
                throw;
            }

            return agents;
        }

        public async Task<Agent> AddAsync(AgentRequest agentRequest)
        {
            Agent agent;

            try
            {
                if (agentRequest == null) throw new ArgumentNullException(nameof(agentRequest), $"{nameof(agentRequest)} cannot be null");

                agent = _mapper.Map<Agent>(agentRequest);
                await _context.Agents.AddAsync(agent);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error adding {nameof(agentRequest)}");
                throw;
            }

            return agent;
        }

        public async Task<Agent> UpdateAsync(Agent agent)
        {
            try
            {
                if (agent == null) throw new ArgumentNullException(nameof(agent), $"{nameof(agent)} cannot be null");

                agent.EntityModified = DateTime.Now;
                _context.Agents.Update(agent);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error updating {nameof(agent)}");
                throw;
            }

            return agent;
        }

        public async Task<Agent> SetInactiveAsync(Agent agent)
        {
            try
            {
                if (agent == null) throw new ArgumentNullException(nameof(agent), $"{nameof(agent)} cannot be null");

                agent.EntityActive = false;
                agent = await UpdateAsync(agent);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error setting inactive {nameof(agent)}");
                throw;
            }

            return agent;
        }
    }
}
