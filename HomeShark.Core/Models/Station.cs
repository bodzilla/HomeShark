using System.Collections.Generic;
using HomeShark.Core.Base;
using HomeShark.Core.Enums;

namespace HomeShark.Core.Models
{
    public sealed class Station : EntityBase
    {
        public Station() => PropertyStations = new List<PropertyStation>();

        public string Name { get; set; }

        public StationType StationType { get; set; }

        public long Latitude { get; set; }

        public long Longitude { get; set; }

        public string GeoLocation => $"{Latitude},{Longitude}";

        public IEnumerable<PropertyStation> PropertyStations { get; set; }
    }
}
