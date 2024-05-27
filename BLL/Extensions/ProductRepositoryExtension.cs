using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Extensions;

public static class ProductRepositoryExtension
{
    public static IQueryable<Product> FilteredByCategoryId(this IQueryable<Product> products, int Id)
    {
        if (Id == 0)
            return products;
        else
            return products.Where(s => s.CategoryID == Id);
    }

    public static IQueryable<Product> FilteredBySearchTerm(this IQueryable<Product> products, string SearchTerm)
    {
        if (string.IsNullOrWhiteSpace(SearchTerm))
            return products;
        else
           return products.Where(s => s.ProductName.ToLower().Contains(SearchTerm.ToLower()));
    }

    public static IQueryable<Product> FilteredByPrice(this IQueryable<Product> products, decimal minPrice, decimal maxPrice, bool isValidPrice)
    {
        if (isValidPrice)
            return products.Where(s => s.ProductPrice >= minPrice && s.ProductPrice <= maxPrice);
        else
            return products;
    }

    public static IQueryable<Product> ToPaginate(this IQueryable<Product> products, int pageNumber, int pageSize)
    {
        return products.Skip(((pageNumber-1)*pageSize)).Take(pageSize);
    }
}
