using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProducatoriLocali.Models
{
    [Table("Product")] 
    public class Product 
    {
        [Key] 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public Guid ProductId { get; set; } 
        [Required(ErrorMessage = "Title is required to be completed.")] 
        [Display(Name = "Title")] 
        public string Title { get; set; } 
        [Display(Name = "Desctription")] 
        public string Description { get; set; } 
        [Required(ErrorMessage = "Price is required to be complete.")] 
        [Display(Name = "Price")] 
        public double Price { get; set; } 
        [Required(ErrorMessage = "Quantity is required to be complete.")] 
        [Display(Name = "Quantity")] 
        public float Quantity { get; set; } 
        public Guid SellerId { get; set; } 
        [Display(Name = "User")] 
        public ApplicationUser User { get; set; } 
        [Display(Name = "Category")] 
        public Category Category { get; set; } 
        [Display(Name = "Subcategory")] 
        public SubCategory SubCategory { get; set; } 
        [Display(Name = "Post start date")] 
        public DateTime PostStartDate { get; set; } 
        [Display(Name = "Post end date")]  
        public DateTime PostEndDate { get; set; }
        [Display(Name = "Locality")]
        public string Locality { get; set; }
    }

    public enum Category 
    { 
        [Display(Name = "Produse alimentare")] 
        ProduseAlimentare, 
        [Display(Name = "Produse de artizanat")] 
        ProduseDeArtizanat 
    }

    public enum SubCategory 
    {
        [Display(Name = "Bauturi alcoolice")] 
        BauturiAlcoolice, 
        [Display(Name = "Bauturi nealcoolice")] 
        BauturiNealcoolice, 
        [Display(Name = "Carne si peste")] 
        CarneSiPeste, 
        [Display(Name = "Conserve si muraturi")] 
        ConserveSiMuraturi, 
        [Display(Name = "Fructe")] 
        Fructe, 
        [Display(Name = "Legume si zarzavaturi")] 
        LegumeSiZarzavaturi, 
        [Display(Name = "Mezeluri si preparate carne")] 
        MezeluriSiPreparateCarne, 
        [Display(Name = "Miere si dulceata")] 
        MiereSiDulceata, 
        [Display(Name = "Oua si lactate")] 
        OuaSiLactate, 
        [Display(Name = "Panificatie")] 
        Panificatie, 
        [Display(Name = "Sanatate")] 
        Sanatate, 
        [Display(Name = "Casa si gradina")] 
        CasaSiGradina, 
        [Display(Name = "Ceramica si sculptura")] 
        CeramicaSculptura, 
        [Display(Name = "Cosmetice")] 
        Cosmetice, 
        [Display(Name = "Lemn si metal")] 
        LemnSiMetal, 
        [Display(Name = "Pictura")] 
        Pictura, 
        [Display(Name = "Pielarie si blanarie")] 
        PielarieBlanarie, 
        [Display(Name = "Tesut/Cusut/Crosetat")] 
        TesutCusutCrosetat 
    }
}