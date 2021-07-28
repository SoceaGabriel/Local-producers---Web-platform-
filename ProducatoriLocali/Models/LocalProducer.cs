using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProducatoriLocali.Models
{
    [Table("LocalProducer")] 
    public class LocalProducer
    {
        [Key] 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public Guid LocalProducerId { get; set; } 
        [Required(ErrorMessage = "Page title is required to complete.")] 
        [Display(Name = "Page title")]  
        public string PageTitle { get; set; } 
        [Display(Name = "Description")] 
        public string Description { get; set; } 
        [Display(Name = "Characteristic ")] 
        public List<string> Characteristics { get; set; } 
        [Display(Name = "Image path")] 
        public string ImagePath { get; set; } 
        [Required(ErrorMessage = "Types of products are required to complete.")] 
        [Display(Name = "Types of products")] 
        public List<SubCategory> TypesOfProducts { get; set; } 

        public LocalProducer() 
        { 
            Characteristics = new List<string>(); 
            TypesOfProducts = new List<SubCategory>(); 
        } 
    }
}