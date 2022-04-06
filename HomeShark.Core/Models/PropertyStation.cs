using System;
using HomeShark.Core.Contracts;

namespace HomeShark.Core.Models
{
    public class PropertyStation : IEntity
    {
        public int Id { get; set; }

        public DateTime EntityCreated { get; set; }

        public DateTime? EntityModified { get; set; }

        public bool EntityActive { get; set; }

        public Property Property { get; set; }

        public int PropertyId { get; set; }

        public Station Station { get; set; }

        public int StationId { get; set; }

        public double DistanceMiles { get; set; }
    }
}
