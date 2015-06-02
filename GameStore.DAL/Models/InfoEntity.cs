


namespace GameStore.DAL.Models
{
    public class InfoEntity : IDataEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        // one to one
        public virtual UserEntity User { get; set; }
    }
}
