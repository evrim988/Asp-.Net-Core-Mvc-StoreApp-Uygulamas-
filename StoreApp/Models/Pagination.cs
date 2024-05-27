

namespace StoreApp.Models;

public class Pagination
{
    public int TotalItems {  get; set; }  //kaç tane ürün listelendi

    public int ItemsPerPages {  get; set; } //sayfa başına düşen kayıt sayısı

    public int CurrentPage {  get; set; } //mevcut sayfa bilgisi

    public int TotalPages => (int)Math.Ceiling((decimal)TotalItems / ItemsPerPages);
}
