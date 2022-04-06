using System;
using HomeShark.Core.Contracts;
using HomeShark.Core.Enums;

namespace HomeShark.Core.Models
{
    public sealed class Media : IEntity
    {
        public int Id { get; set; }

        public DateTime EntityCreated { get; set; }

        public DateTime? EntityModified { get; set; }

        public bool EntityActive { get; set; }

        public Property Property { get; set; }

        public int PropertyId { get; set; }

        public Uri Uri { get; set; }

        public MediaType MediaType { get; set; }

        public int OrderRank { get; set; }
    }
}
