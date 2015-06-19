
using GameStore.Model.Common;
using System;
namespace GameStore.Model
{
    public class Support : ISupport
    {
        public Guid Id { get; set; }

        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        // One to one
        public virtual IPublisher Publisher { get; set; }

    }
}
