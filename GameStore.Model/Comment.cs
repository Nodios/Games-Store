using GameStore.Model.Common;
using System;

namespace GameStore.Model
{
    /// <summary>
    /// Business logic model
    /// </summary>
    public class Comment : IComment
    {
        public Guid Id { get; set; }
        public Guid PostId { get; set; }
        public string UserId { get; set; }

        public int VotesUp { get; set; }
        public int VotesDown { get; set; }
        public string Description { get; set; }
        public string UserName { get; set; }
        public DateTime Date { get; set; }


        public IUser User { get; set; }
        public IPost Post { get; set; }
    }
}
