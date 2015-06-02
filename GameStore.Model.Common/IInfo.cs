using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameStore.Model.Common
{
    public interface IInfo
    {
        int Id { get; set; }
        string Name { get; set; }
        string Surname { get; set; }
        string Email { get; set; }
        string Address { get; set; }

        // one to one
        IUser User { get; set; }
    }
}
