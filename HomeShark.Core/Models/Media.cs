using System;
using HomeShark.Core.Base;
using HomeShark.Core.Enums;

namespace HomeShark.Core.Models
{
    public sealed class Media : EntityBase
    {
        public Property Property { get; set; }

        public int PropertyId { get; set; }

        public Uri Uri { get; set; }

        public MediaType MediaType { get; set; }

        public int DisplayOrder { get; set; }
    }
}
