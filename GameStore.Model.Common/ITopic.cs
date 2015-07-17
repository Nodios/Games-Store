using System;
using System.Collections.Generic;

namespace GameStore.Model.Common
{
    /// <summary>
    /// Provides minimum implementation for topic entity
    /// </summary>
    public interface ITopic
    {
        Guid Id { get; set; }
        string UserId { get; set; }
        string Title { get; set; }
        string UserName { get; set; }
        ICollection<IPost> Posts { get; set; }      
    }
}
