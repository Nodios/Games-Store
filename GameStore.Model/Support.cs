
using GameStore.Model.Common;
namespace GameStore.Model
{
    public class Support : ISupport
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        // One to one
        public virtual ICompany Company { get; set; }

    }
}
