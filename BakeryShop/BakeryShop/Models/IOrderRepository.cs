﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BakeryShop.Models
{
    interface IOrderRepository
    {
        public void CreateOrder(Order order);
    }
}