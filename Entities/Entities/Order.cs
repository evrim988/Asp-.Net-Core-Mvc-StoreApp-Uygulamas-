using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class Order : BaseEntity
    {
        [DisplayName("Sipariş Adı")]
        public string OrderName { get; set; }

        [DisplayName("Sipariş Açıklaması")]
        public string? OrderDescription {  get; set; }

        [DisplayName("Ülke")]
        public string Country { get; set; }

        [DisplayName("Şehir")]
        public string City {  get; set; }

        [DisplayName("İlçe")]
        public string District { get; set; }

        [DisplayName("Adres Açıklaması")]
        public string AddressDescription { get; set; }

        [DisplayName("Telefon")]
        public int PhoneNumber {  get; set; }

        [DisplayName("Hediye Paketi Olacak mı?")]
        public bool GiftWrap {  get; set; }

        [DisplayName("Sipariş Kargoya Verildi Mi?")]
        public bool Shipped {  get; set; }

        [DisplayName("Sipariş Verilme Tarihi")]
        public DateTime OrderedDate { get; set; } = DateTime.Now;

        public ICollection<CartLine> Lines { get; set; } = new List<CartLine>();
    }
}
