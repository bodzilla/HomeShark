using System;
using System.Collections.Generic;
using HomeShark.Core.Contracts;
using HomeShark.Core.Enums;

namespace HomeShark.Core.Models
{
    public sealed class School : IEntity
    {
        public School() => PropertySchools = new List<PropertySchool>();

        public int Id { get; set; }

        public DateTime EntityCreated { get; set; }

        public DateTime? EntityModified { get; set; }

        public bool EntityActive { get; set; }

        public string Name { get; set; }

        public SchoolType SchoolType { get; set; }

        public long Latitude { get; set; }

        public long Longitude { get; set; }

        public string GeoLocation => $"{Latitude},{Longitude}";

        public IEnumerable<PropertySchool> PropertySchools { get; set; }
    }
}
