using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HomeShark.Core.Contracts.Services;
using HomeShark.Core.Dtos.Requests;
using HomeShark.Core.Models;
using HomeShark.Persistence;
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
                _logger.LogError(ex, $"Error getting all {nameof(Agent)}");
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
                _logger.LogError(ex, $"Error getting {nameof(Agent)} by ID {id}");
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
                _logger.LogError(ex, $"Error getting {nameof(Agent)} by {nameof(name)} {nameof(Agent.Name)}");
                throw;
            }
        }

        public async Task<Agent> AddAsync(AddAgentRequest request)
        {
            try
            {
                if (request == null) throw new ArgumentNullException(nameof(request), $"{nameof(AddAgentRequest)} cannot be null");

                var agent = _mapper.Map<Agent>(request);
                await _context.Agents.AddAsync(agent);
                await _context.SaveChangesAsync();
                return agent;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error adding {nameof(AddAgentRequest)}");
                throw;
            }
        }

        public async Task<Agent> UpdateAsync(UpdateAgentRequest request)
        {
            try
            {
                if (request == null) throw new ArgumentNullException(nameof(request), $"{nameof(UpdateAgentRequest)} cannot be null");

                var agent = _mapper.Map<Agent>(request);
                if (!await _context.Agents.AnyAsync(x => x.Id == agent.Id)) throw new ArgumentException($"{nameof(Agent)} with ID {agent.Id} does not exist");

                agent.EntityModified = DateTime.Now;
                _context.Agents.Update(agent);
                await _context.SaveChangesAsync();
                return agent;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error updating {nameof(UpdateAgentRequest)}");
                throw;
            }
        }

        public async Task<Agent> SetInactiveAsync(int id)
        {
            try
            {
                if (id <= 0) throw new ArgumentOutOfRangeException(nameof(id), id, $"{nameof(id)} must be greater than 0");

                var agent = await _context.Agents.FindAsync(id) ?? throw new NullReferenceException($"{nameof(Agent)} with ID {id} does not exist");

                agent.EntityActive = false;
                agent.EntityModified = DateTime.Now;
                _context.Agents.Update(agent);
                await _context.SaveChangesAsync();
                return agent;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error setting inactive {nameof(Agent)}");
                throw;
            }
        }
    }
}
