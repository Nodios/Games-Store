

namespace GameStore.DAL.Models
{
    public class SupportEntity : IDataEntity
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        // One to one
        public virtual CompanyEntity Company { get; set; }
    }
}
