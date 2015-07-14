using System.Collections.Generic;

namespace GameStore.Model.Common
{
    public interface IUser
    {
        string Id { get; set; }
        string UserName { get; set; }
        string PasswordHash { get; set; }
        string Email { get; set; }

        // One to one 
        IInfo Info { get; set; }
        ICart Cart { get; set; }

        // One to many
        ICollection<IComment> Comments { get; set; }
        ICollection<IPost> Posts { get; set; }
        ICollection<IReview> Reviews { get; set; }
        ICollection<IOrder> Orders { get; set; }
    }
}
