using HomeShark.Core.Base;

namespace HomeShark.Core.Models
{
    public sealed class PropertyStation : EntityBase
    {
        public Property Property { get; set; }

        public int PropertyId { get; set; }

        public Station Station { get; set; }

        public int StationId { get; set; }

        public double DistanceMiles { get; set; }
    }
}
