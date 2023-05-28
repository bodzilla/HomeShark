using System.Collections.Generic;
using HomeShark.Core.Base;

namespace HomeShark.Core.Models
{
    public sealed class Agent : EntityBase
    {
        public Agent() => AgentBranches = new List<AgentBranch>();

        public string Name { get; set; }

        public string Website { get; set; }

        public string Logo { get; set; }

        public IEnumerable<AgentBranch> AgentBranches { get; set; }
    }
}
