
using System;
namespace GameStore.Model.Common
{
    public interface ISupport
    {
        Guid Id { get; set; }
        string Email { get; set; }
        string Address { get; set; }
        string Phone { get; set; }

        // One to one
        IPublisher Publisher { get; set; }

    }
}
