

namespace GameStore.DAL.Models
{
    public class SupportEntity 
    {
        public int PublisherId { get; set; }

        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        // One to one
        public virtual PublisherEntity Publisher { get; set; }
    }
}
