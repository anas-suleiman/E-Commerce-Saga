using System;
using System.Collections.Generic;

namespace Product.DataAccess
{
    public partial class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int ShopId { get; set; }
    }
}
