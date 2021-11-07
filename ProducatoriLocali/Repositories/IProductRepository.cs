using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProducatoriLocali.Models;

namespace ProducatoriLocali.Repositories
{
    public interface IProductRepository
    {
        ApiProductResponse CreateProduct(Product product, string UserId);
        ApiProductResponse EditProduct(string productId);
        ApiProductResponse DeleteProduct(string productId);
        List<Product> GetAllProduct();
        Product GetProduct(string productId);

    }
}
