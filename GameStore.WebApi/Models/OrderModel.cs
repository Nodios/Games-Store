using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameStore.WebApi.Models
{
    public class OrderModel
    {
        private string dateTime;

        public Guid Id { get; set; }
        public string UserId { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string DeliveryAddress { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }
        public string OrderDate { get; set; }      
        public double Amount { get; set; }

        public virtual UserModel User { get; set; }
        public ICollection<GameModel> Games { get; set; }
    }
}