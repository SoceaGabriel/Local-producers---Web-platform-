using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProducatoriLocali.Models;

namespace ProducatoriLocali.Repositories
{
    public class ProductRepo : IProductRepository
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public ApiProductResponse CreateProduct(Product product, string UserId)
        {
            try
            {
                if(product.Title.Length > 10 && product.Price >= 0 && product.Quantity > 0 && product.UnitsNumber > 0)
                {
                    var usrId = Guid.Parse(UserId);
                    var user = db.Utilizatori.Where(x => x.UserId == usrId).FirstOrDefault();
                    var data = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
                    Product pr = new Product
                    {
                        Category = product.Category,
                        Description = product.Description.Replace("\r\n", "<br/>"),
                        ImagePath = product.ImagePath,
                        Locality = product.Locality,
                        Price = product.Price,
                        Quantity = product.Quantity,
                        SubCategory = product.SubCategory,
                        Title = product.Title,
                        UnitsNumber = product.UnitsNumber,
                        SellerId = usrId,
                        PostStartDate = data,
                        PostEndDate = data.AddMonths(1)
                    };
                    db.Products.Add(pr);
                    db.SaveChanges();
                    return ApiProductResponse.ADDPRODUCT_SUCCESS;
                }
                else
                {
                    return ApiProductResponse.ADDPRODUCT_ERROR;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error: ProductRepo - CreateProduct: " + ex);
                return ApiProductResponse.ADDPRODUCT_ERROR;
            }
        }

        public ApiProductResponse DeleteProduct(string productId)
        {
            throw new NotImplementedException();
        }

        public ApiProductResponse EditProduct(string productId)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllProduct()
        {
            throw new NotImplementedException();
        }

        public Product GetProduct(string productId)
        {
            throw new NotImplementedException();
        }
    }
}