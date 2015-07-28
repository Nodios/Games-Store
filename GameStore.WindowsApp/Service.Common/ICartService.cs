using GameStore.WindowsApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.WindowsApp.Service.Common
{
    public interface ICartService
    {
        Task<Cart> GetAsync(string userId);
        Task<int> UpdateAsync(Cart cart);
    }
}
