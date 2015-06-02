using GameStore.Model.Common;
using System.Collections.Generic;

namespace GameStore.Model
{
    public class Company : ICompany
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // One to one 
        public virtual ISupport Support { get; set; }

        // One to many
        public virtual ICollection<IGame> Games { get; set; }
    }
}
