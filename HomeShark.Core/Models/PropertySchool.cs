using System;
using HomeShark.Core.Contracts;

namespace HomeShark.Core.Models
{
    public class PropertySchool : IEntity
    {
        public int Id { get; set; }

        public DateTime EntityCreated { get; set; }

        public DateTime? EntityModified { get; set; }

        public bool EntityActive { get; set; }

        public Property Property { get; set; }

        public int PropertyId { get; set; }

        public School School { get; set; }

        public int SchoolId { get; set; }

        public double DistanceMiles { get; set; }
    }
}
