using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class CartLine : BaseEntity
    {
        [DisplayName("Miktar")]
        public int Quantity { get; set; }
        
        [DisplayName("Ürün")]
        public int ProductId {  get; set; }
        public Product Product { get; set; }
    }
}
