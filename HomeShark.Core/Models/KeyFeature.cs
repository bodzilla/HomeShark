using HomeShark.Core.Base;

namespace HomeShark.Core.Models
{
    public sealed class KeyFeature : EntityBase
    {
        public Property Property { get; set; }

        public int PropertyId { get; set; }

        public string Text { get; set; }

        public int DisplayOrder { get; set; }
    }
}
