using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities;

public class Category : BaseEntity
{
    [DisplayName("Kategori Adı")]
    public string CategoryName {  get; set; }

    [DisplayName("Kategori Açıklaması")]
    public string? CategoryDescription { get; set; }

    public ICollection<Category> Categories { get; set;}
}
