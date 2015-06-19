using System;
using System.Collections.Generic;

namespace GameStore.Model.Common
{
    public interface IPublisher
    {
        Guid Id { get; set; }

        string Name { get; set; }
        string Description { get; set; }

        // One to one 
        ISupport Support { get; set; }

        // One to many
        ICollection<IGame> Games { get; set; }
    }
}
