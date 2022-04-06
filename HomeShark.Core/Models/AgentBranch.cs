using System;
using System.Collections.Generic;
using System.ComponentModel;
using HomeShark.Core.Contracts;

namespace HomeShark.Core.Models
{
    public sealed class AgentBranch : IEntity
    {
        public AgentBranch() => Properties = new List<Property>();

        public int Id { get; set; }

        public DateTime EntityCreated { get; set; }

        public DateTime? EntityModified { get; set; }

        public bool EntityActive { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public string Phone { get; set; }

        public Agent Agent { get; set; }

        public int AgentId { get; set; }

        public IEnumerable<Property> Properties { get; set; }
    }
}
