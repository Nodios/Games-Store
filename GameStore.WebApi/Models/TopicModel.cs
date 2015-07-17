using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameStore.WebApi.Models
{
    /// <summary>
    /// Topic model
    /// </summary>
    public class TopicModel
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public string UserName { get; set; }
    }
}