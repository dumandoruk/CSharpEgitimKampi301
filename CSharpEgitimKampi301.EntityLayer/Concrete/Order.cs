﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEgitimKampi301.EntityLayer.Concrete
{
    // Order entity sınıfı
    public class Order
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int Quanity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
