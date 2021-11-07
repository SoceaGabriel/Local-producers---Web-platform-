using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProducatoriLocali.Models
{
    public class ProductDTO
    {
        public Guid ProductId { get; set; }
        [Display(Name = "Titlu")]
        public string Title { get; set; }
        [Display(Name = "Descriere")]
        public string Description { get; set; }
        [Display(Name = "Pret")]
        public double Price { get; set; }
        [Display(Name = "Cantitate")]
        public float Quantity { get; set; }
        [Display(Name = "Numar de unitati")]
        public int UnitsNumber { get; set; }
        public Guid SellerId { get; set; }
        public User Seller { get; set; }
        [Display(Name = "Categorie")]
        public Category Category { get; set; }
        [Display(Name = "Subcategorie")]
        public SubCategory SubCategory { get; set; }
        [Display(Name = "Data postarii")]
        public DateTime? PostStartDate { get; set; }
        [Display(Name = "Data de sfarsit a postarii")]
        public DateTime? PostEndDate { get; set; }
        [Display(Name = "Judet")]
        public string Locality { get; set; }
        [Display(Name = "ImagePath")]
        public string ImagePath { get; set; }
    }
}