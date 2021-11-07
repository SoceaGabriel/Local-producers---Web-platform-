using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProducatoriLocali.Models
{
    public class MainPageProductsViewModel
    {
        public List<Product> MostViewed { get; set; }
        public List<Product> NewProducts { get; set; }
        public List<Product> MostScored { get; set; }

        public MainPageProductsViewModel()
        {
            MostViewed = new List<Product>();
            NewProducts = new List<Product>();
            MostScored = new List<Product>();
        }
    }
}