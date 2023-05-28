using System.Collections.Generic;
using HomeShark.Core.Base;
using HomeShark.Core.Enums;

namespace HomeShark.Core.Models
{
    public sealed class School : EntityBase
    {
        public School() => PropertySchools = new List<PropertySchool>();

        public string Name { get; set; }

        public SchoolType SchoolType { get; set; }

        public long Latitude { get; set; }

        public long Longitude { get; set; }

        public string GeoLocation => $"{Latitude},{Longitude}";

        public IEnumerable<PropertySchool> PropertySchools { get; set; }
    }
}
