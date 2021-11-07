using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProducatoriLocali.Models
{
    public class UserProductsViewModel
    {
        public List<Product> ActivePosts { get; set; }
        public List<Product> InactivePosts { get; set; }
        public User Utilizator { get; set; }

        public UserProductsViewModel()
        {
            ActivePosts = new List<Product>();
            InactivePosts = new List<Product>();
        }
    }
}