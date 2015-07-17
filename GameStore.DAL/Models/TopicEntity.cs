
using System;
using System.Collections.Generic;
namespace GameStore.DAL.Models
{
    /// <summary>
    /// Database model
    /// </summary>
    public class TopicEntity 
    {
        public Guid Id {get; set;}
        public string UserId { get; set; }
        public string Title { get; set; }
        public string UserName { get; set; }

        public virtual UserEntity User { get; set; }
        public virtual ICollection<PostEntity> Posts {get; set;}
    }
}