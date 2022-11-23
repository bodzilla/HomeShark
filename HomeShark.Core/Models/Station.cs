using System;
using System.Collections.Generic;
using HomeShark.Core.Contracts;
using HomeShark.Core.Enums;

namespace HomeShark.Core.Models
{
    public sealed class Station : IEntity
    {
        public Station() => PropertyStations = new List<PropertyStation>();

        public int Id { get; set; }

        public DateTime EntityCreated { get; set; }

        public DateTime? EntityModified { get; set; }

        public bool EntityActive { get; set; }

        public string Name { get; set; }

        public StationType StationType { get; set; }

        public long Latitude { get; set; }

        public long Longitude { get; set; }

        public string GeoLocation => $"{Latitude},{Longitude}";

        public IEnumerable<PropertyStation> PropertyStations { get; set; }
    }
}
