﻿using System;

namespace GameStore.WebApi.Models
{
    public class ReviewModel
    {
        public Guid Id { get; set; }
        public Guid GameId { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public float Score { get; set; }
    }

}