﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationAPI.Domain.Entites.Common
{
    public class BaseEntity
    {
        public int Id { get; set; }

        public DateTime CreatedTime { get; set; } = DateTime.UtcNow;

    }
}
