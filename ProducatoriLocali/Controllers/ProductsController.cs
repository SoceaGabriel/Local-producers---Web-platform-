using ProducatoriLocali.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Reflection;

namespace ProducatoriLocali.Controllers
{
    public class ProductsController : Controller
    {
        public string schema = "http://";
        public string host = "localhost";
        public string port = "64103";
        public ApplicationDbContext db = new ApplicationDbContext();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetProducts(Category? Category, SubCategory? SubCategory, string SearchedWords, string Judet, DateTime? StartDate, int? MinPrice, int? MaxPrice)
        {
            List<ProductDTO> productList = new List<ProductDTO>();
            var products = db.Products.ToList();
            if(Category != null)
            {
                TempData["Category"] = Category;
                products = products.Where(x => x.Category == Category).ToList();
            }

            if (SubCategory != null)
            {
                TempData["SubCategory"] = Category;
                products = products.Where(x => x.SubCategory == SubCategory).ToList();
            }

            if(!string.IsNullOrEmpty(SearchedWords))
            {
                TempData["SearchedWords"] = SearchedWords;
                products = products.Where(x => x.Title.ToUpper().Contains(SearchedWords.ToUpper())).ToList();
            }

            if( Judet != "Judet" && !string.IsNullOrEmpty(Judet))
            {
                TempData["Judet"] = Judet;
                products = products.Where(x => x.Locality == Judet).ToList();
            }

            if(StartDate != null)
            {
                TempData["StartDate"] = StartDate;
                products = products.Where(x => x.PostStartDate > StartDate && x.PostEndDate >= DateTime.Now).ToList();
            }

            if(MinPrice != null)
            {
                TempData["MinPrice"] = MinPrice;
                products = products.Where(x => x.Price >= MinPrice).ToList();
            }

            if (MaxPrice != null)
            {
                TempData["MaxPrice"] = MaxPrice;
                products = products.Where(x => x.Price <= MaxPrice).ToList();
            }
            foreach (var pr in products)
            {
                var user = db.Utilizatori.Where(x => x.UserId == pr.SellerId).FirstOrDefault();
                ProductDTO prod = new ProductDTO
                {
                    Category = pr.Category,
                    Description = pr.Description,
                    ImagePath = pr.ImagePath,
                    Locality = pr.Locality,
                    PostEndDate = pr.PostEndDate,
                    PostStartDate = pr.PostStartDate,
                    Price = pr.Price,
                    ProductId = pr.ProductId,
                    Quantity = pr.Quantity,
                    Seller = user,
                    SellerId = user.UserId,
                    SubCategory = pr.SubCategory,
                    Title = pr.Title,
                    UnitsNumber = pr.UnitsNumber
                };
                productList.Add(prod);
            }
            TempData["ProductsList"] = productList;
            return RedirectToAction("Products", "Products");
        }

        [HttpGet]
        public ActionResult Products()
        {
            if(TempData["ProductsList"] != null)
            {
                var prodlist = TempData["ProductsList"];
                return View(prodlist);
            }
            else
            {
                var products = db.Products.ToList();
                List<ProductDTO> productList = new List<ProductDTO>();
                foreach (var pr in products)
                {
                    var user = db.Utilizatori.Where(x => x.UserId == pr.SellerId).FirstOrDefault();
                    ProductDTO prod = new ProductDTO
                    {
                        Category = pr.Category,
                        Description = pr.Description,
                        ImagePath = pr.ImagePath,
                        Locality = pr.Locality,
                        PostEndDate = pr.PostEndDate,
                        PostStartDate = pr.PostStartDate,
                        Price = pr.Price,
                        ProductId = pr.ProductId,
                        Quantity = pr.Quantity,
                        Seller = user,
                        SellerId = user.UserId,
                        SubCategory = pr.SubCategory,
                        Title = pr.Title,
                        UnitsNumber = pr.UnitsNumber
                    };
                    productList.Add(prod);
                }
                return View(productList);
            }
            
        }

        [HttpGet]
        public ActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(Product product)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(schema + host + ":" + port + "/api/apiproduct");
                var postTask = client.PostAsJsonAsync<Product>("/api/apiproduct/addprod?UserId=" + Session["LocalProducerAppUserId"].ToString(), product);
                postTask.Wait();
                var result = postTask.Result;
                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    ViewBag.ResponseType = "Ok";
                    ViewBag.Message = "Ati adaugat produsul cu succes!";
                    return View();
                }
                else
                {
                    ViewBag.ResponseType = "Error";
                    ViewBag.Message = "Eroare la procesarea datelor. Va rugam sa completati toate campurile necesare si sa incercati din nou";
                    return View(product);
                }
            }
        }

        [HttpGet]
        public ActionResult ProductDetails(Guid ProdId)
        {
            var pr = db.Products.Where(x => x.ProductId == ProdId).FirstOrDefault();
            var user = db.Utilizatori.Where(x => x.UserId == pr.SellerId).FirstOrDefault();

            ProductDTO prod = new ProductDTO
            {
                Category = pr.Category,
                Description = pr.Description.Replace("<br/>", "\r\n"),
                ImagePath = pr.ImagePath,
                Locality = pr.Locality,
                PostEndDate = pr.PostEndDate,
                PostStartDate = pr.PostStartDate,
                Price = pr.Price,
                ProductId = pr.ProductId,
                Quantity = pr.Quantity,
                Seller = user,
                SellerId = user.UserId,
                SubCategory = pr.SubCategory, //.GetType().GetMember(pr.SubCategory.ToString())[0].GetCustomAttributes(typeof(System.ComponentModel.DisplayNameAttribute), false),
                Title = pr.Title,
                UnitsNumber = pr.UnitsNumber
            };
            return View(prod);
        }
    }
}