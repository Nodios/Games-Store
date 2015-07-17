using System;

namespace GameStore.Model.Common
{
    /// <summary>
    /// Interface for user info implementation
    /// </summary>
    public interface IInfo
    {
        Guid Id { get; set; }

        string Name { get; set; }
        string Surname { get; set; }
        string Email { get; set; }
        string Address { get; set; }

        // one to one
        IUser User { get; set; }
    }
}
