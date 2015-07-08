using System;

namespace GameStore.WebApi.Models
{
    /// <summary>
    /// Support class
    /// </summary>
    public class SupportModel
    {
        public Guid PublisherId { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}