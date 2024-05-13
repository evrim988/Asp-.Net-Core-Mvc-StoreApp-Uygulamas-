using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class Cart : BaseEntity
    {
        public List<CartLine> Lines { get; set; }

        public Cart() 
        {
            Lines = new List<CartLine>();
        }

        public void AddItem(Product model, int quantity)
        {
            var lines = Lines.Where(s => s.ProductId == model.Id).FirstOrDefault();

            if(lines == null)
            {
                Lines.Add(new CartLine()
                {
                    Product = model,
                    ProductId = model.Id,
                    Quantity = quantity
                });
            }
            else
            {
                lines.Quantity += quantity;
            }
        }

        public void RemoveLine(Product model) => Lines.RemoveAll(s => s.Product.Id == model.Id);

        public decimal TotalValue() => Lines.Sum(s => s.Product.ProductPrice *  s.Quantity);

        public void Clear() => Lines.Clear();
    }
}
