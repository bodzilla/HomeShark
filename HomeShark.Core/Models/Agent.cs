using System;
using System.Collections.Generic;
using HomeShark.Core.Contracts;

namespace HomeShark.Core.Models
{
    public sealed class Agent : IEntity
    {
        public Agent() => AgentBranches = new List<AgentBranch>();

        public int Id { get; set; }

        public DateTime EntityCreated { get; set; }

        public DateTime? EntityModified { get; set; }

        public bool EntityActive { get; set; }

        public string Name { get; set; }

        public string Website { get; set; }

        public string Logo { get; set; }

        public IEnumerable<AgentBranch> AgentBranches { get; set; }
    }
}
