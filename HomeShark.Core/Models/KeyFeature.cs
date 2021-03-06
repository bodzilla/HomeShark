using System;
using HomeShark.Core.Contracts;

namespace HomeShark.Core.Models
{
    public sealed class KeyFeature : IEntity
    {
        public int Id { get; set; }

        public DateTime EntityCreated { get; set; }

        public DateTime? EntityModified { get; set; }

        public bool EntityActive { get; set; }

        public Property Property { get; set; }

        public int PropertyId { get; set; }

        public string Text { get; set; }

        public int OrderRank { get; set; }
    }
}
