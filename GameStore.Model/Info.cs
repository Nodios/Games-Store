
using GameStore.Model.Common;
using System;
namespace GameStore.Model
{
    public class Info : IInfo
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        // one to one
        public virtual IUser User { get; set; }
    }
}
