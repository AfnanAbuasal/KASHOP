﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KASHOP.DAL.Models
{
    public class BaseModel
    {
        public int ID { get; set; }
        public DateTime CreatedAt { get; set; }
        public Status Status { get; set; }
    }

    public enum Status
    {
        Active = 1,
        Inactive = 0
    }
}
