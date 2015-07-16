using System;
using System.Collections.Generic;

namespace GameStore.DAL.Models
{
    /// <summary>
    /// Database entity
    /// </summary>
    public class OrderEntity : IDataEntity
    {
        private string dateTime;
        private Guid id;

        public Guid Id
        {
            get { return id; }
            set
            {
                // Set to new only if there is no guid provided
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

        /// <summary>
        /// Public get, Set to new only if from null
        /// </summary>
        public string OrderDate
        {
            get { return dateTime; }
            set
            {
                if (value == null)
                {
                    // s is filtering option
                    dateTime = DateTime.Now.ToString("s");
                }
                else
                    dateTime = value;
            }
        }
        public double Amount { get; set; }

        public virtual UserEntity User { get; set; }
        public virtual ICollection<GameEntity> Games { get; set; }


    }
}
