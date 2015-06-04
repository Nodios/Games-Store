
using System.Collections.Generic;

namespace GameStore.DAL.Models
{
    public class PublisherEntity : IDataEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        // One to one 
        public virtual SupportEntity Support { get; set; }

        // One to many
        public virtual ICollection<GameEntity> Games { get; set; }
    }
}
