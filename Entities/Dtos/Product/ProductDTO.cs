﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.Product
{
    public class ProductDTO
    {
        public string ProductName { get; set; }

        public string? ProductDescription { get; set; }

        public decimal ProductPrice { get; set; }

        public string? Summary {  get; set; }

        public string? ImageUrl {  get; set; }

        public int CategoryId { get; set; }
    }
}
