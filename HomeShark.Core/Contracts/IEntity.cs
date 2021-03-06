using System;

namespace HomeShark.Core.Contracts
{
    public interface IEntity
    {
        int Id { get; set; }

        DateTime EntityCreated { get; set; }

        DateTime? EntityModified { get; set; }

        bool EntityActive { get; set; }
    }
}
