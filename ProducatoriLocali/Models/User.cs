using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProducatoriLocali.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UserId { get; set; }
        [Required(ErrorMessage = "Name is required to be completed.")]
        [Display(Name = "Nume")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "FirstName is required to be completed.")]
        [Display(Name = "Prenume")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Email is required to be completed.")]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required to be completed.")]
        [Display(Name = "Parola")]
        public string Password { get; set; }
        [Display(Name = "Reintroduceti parola")]
        public string ReenteredPassword { get; set; }
        [Display(Name = "Numar de telefon")]
        public string PhoneNumber { get; set; }
    }
}