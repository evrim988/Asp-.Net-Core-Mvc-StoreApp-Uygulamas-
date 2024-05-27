using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.RequestParameters;

public class ProductRequestParameters : RequestParameters   //burası repository de kullanılıyor.
{
    public ProductRequestParameters() : this(1, 6)
    {

    }
    public ProductRequestParameters(int pageNumber, int pageSize)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
    }

    public int Id { get; set; }

    public decimal MinPrice { get; set; } = 0;

    public decimal MaxPrice { get; set; } = int.MaxValue;

    public bool IsValidPrice => MaxPrice > MinPrice;

    public int PageNumber {  get; set; }

    public int PageSize { get; set; }
}
