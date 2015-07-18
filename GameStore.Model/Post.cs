using GameStore.Model.Common;
using System;
using System.Collections.Generic;

namespace GameStore.Model
{
    /// <summary>
    /// Business logic model
    /// </summary>
    public class Post : IPost
    {
        public Guid TopicId { get; set; }
        public Guid Id { get; set; }
        public string UserId { get; set; }

        public int VotesUp { get; set; }
        public int VotesDown { get; set; }
        public string Description { get; set; }
        public string UserName { get; set; }
        public DateTime Date { get; set; }

        public IUser User { get; set; }
        public ITopic Topic { get; set; }

        public ICollection<IComment> Comments { get; set; }
    }
}
