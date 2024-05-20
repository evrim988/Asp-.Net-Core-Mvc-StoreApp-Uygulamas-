using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.RequestParameters;

public class ProductRequestParameters : RequestParameters
{
    public int Id { get; set; }

    public decimal MinPrice { get; set; } = 0;

    public decimal MaxPrice { get; set; } = int.MaxValue;

    public bool IsValidPrice => MaxPrice > MinPrice;
}
