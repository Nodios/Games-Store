﻿using System;

namespace GameStore.WebApi.Models
{
    /// <summary>
    /// Publisher class
    /// </summary>
    public class PublisherModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual SupportModel Support {get; set;}
    }

}