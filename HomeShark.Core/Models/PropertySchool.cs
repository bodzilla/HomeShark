using HomeShark.Core.Base;

namespace HomeShark.Core.Models
{
    public sealed class PropertySchool : EntityBase
    {
        public Property Property { get; set; }

        public int PropertyId { get; set; }

        public School School { get; set; }

        public int SchoolId { get; set; }

        public double DistanceMiles { get; set; }
    }
}
