using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class Product : BaseEntity
    {
        [DisplayName("Ürün Adı")]
        public string ProductName { get; set; }

        [DisplayName("Ürün Açıklaması")]
        public string? ProductDescription { get; set; }

        [DisplayName("Ürün Fiyatı")]
        public decimal ProductPrice { get; set; }

        [DisplayName("Kategori")]
        public int? CategoryID {  get; set; }

        public Category Category { get; set; }
    }
}
