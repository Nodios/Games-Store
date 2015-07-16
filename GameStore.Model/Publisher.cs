using GameStore.Model.Common;
using System;
using System.Collections.Generic;

namespace GameStore.Model
{
    /// <summary>
    /// Business logic model
    /// </summary>
    public class Publisher : IPublisher
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        // One to one 
        public virtual ISupport Support { get; set; }

        // One to many
        public virtual ICollection<IGame> Games { get; set; }
    }
}
