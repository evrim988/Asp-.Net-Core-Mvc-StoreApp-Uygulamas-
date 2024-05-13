using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class Product : BaseEntity
    {
        [DisplayName("Ürün Adı")]
        [Required(ErrorMessage = "Ürün Adı Boş Geçilemez")]
        public string ProductName { get; set; }

        [DisplayName("Ürün Açıklaması")]
        public string? ProductDescription { get; set; }

        public string? Summary {  get; set; }

        [DisplayName("Ürün Resmi")]
        public string? ImageUrl {  get; set; }

        [DisplayName("Ürün Fiyatı")]
        [Required(ErrorMessage = "Ürün Fiyatı Boş Geçilemez")]
        public decimal ProductPrice { get; set; }

        public int? CategoryID {  get; set; }
        public Category? Category { get; set; }
    }
}
