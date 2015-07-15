using System;
using System.Collections.Generic;

namespace GameStore.DAL.Models
{
    public class OrderEntity : IDataEntity
    {
        private string dateTime;
        private Guid id;

        public Guid Id
        {
            get { return id; }
            set
            {
                if (value == Guid.Empty || value == null)
                    id = Guid.NewGuid();
                else
                    id = value;
            }
        }
        public string UserId { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string DeliveryAddress { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }
        public string OrderDate
        {
            get { return dateTime; }
            set
            {
                if (value == null)
                    dateTime = DateTime.Now.ToString("s");
                else
                    dateTime = value;
            }
        }
        public double Amount { get; set; }

        public virtual UserEntity User { get; set; }
        public virtual ICollection<GameEntity> Games { get; set; }


    }
}
