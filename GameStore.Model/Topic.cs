using GameStore.Model.Common;
using System;
using System.Collections.Generic;

namespace GameStore.Model
{
    /// <summary>
    /// Topic model
    /// </summary>
    public class Topic : ITopic
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public string UserName { get; set; }
        public ICollection<IPost> Posts { get; set; }
    }
}
