

using System;
namespace GameStore.DAL.Models
{
    /// <summary>
    /// Database entity
    /// </summary>
    public class SupportEntity 
    {
        public Guid PublisherId { get; set; }

        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        // One to one
        public virtual PublisherEntity Publisher { get; set; }
    }
}
