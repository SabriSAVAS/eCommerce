﻿using eCommerce.Data.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Service.Orders
{
   public class OrderService:BaseService<Order>,IOrderService<Order>
    {
    }
}
