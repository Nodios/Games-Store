
namespace GameStore.DAL.Models
{
    public abstract class PostsAndComments : IDataEntity
    {
        public int Id { get; set; }
        public int VotesUp { get; set; }
        public int VotesDown { get; set; }
        public string Description { get; set; }
    }
}
