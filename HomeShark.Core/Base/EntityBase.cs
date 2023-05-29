using System;

namespace HomeShark.Core.Base
{
    public class EntityBase
    {
        public EntityBase()
        {
            EntityCreated = DateTime.Now;
            EntityActive = true;
        }

        public int Id { get; set; }

        public DateTime EntityCreated { get; set; }

        public DateTime? EntityModified { get; set; }

        public bool EntityActive { get; set; }
    }
}
