using System;
using System.Collections.Generic;

namespace GameStore.Model.Common
{
    /// <summary>
    /// Interface for order
    /// </summary>
    public interface IOrder
    {
         Guid Id { get; set; }
         string UserId { get; set; }

         string Name { get; set; }
         string Surname { get; set; }
         string DeliveryAddress { get; set; }
         string ContactEmail { get; set; }
         string ContactPhone { get; set; }
         string OrderDate { get; set; }
         double Amount { get; set; }

         IUser User { get; set; }
         ICollection<IGame> Games { get; set; }
    }
}
