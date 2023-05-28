using System.Collections.Generic;
using HomeShark.Core.Base;

namespace HomeShark.Core.Models
{
    public sealed class AgentBranch : EntityBase
    {
        public AgentBranch() => Properties = new List<Property>();

        public string Name { get; set; }

        public string Location { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public Agent Agent { get; set; }

        public int AgentId { get; set; }

        public IEnumerable<Property> Properties { get; set; }
    }
}
