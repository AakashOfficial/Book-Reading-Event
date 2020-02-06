﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Reading_Event_DAO
{
    class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserComment { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int EventId { get; set; }
        public Event Event { get; set; }
    }
} 