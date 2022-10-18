using eTickets.Data.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Producer:IEntityBase
    {
        // actor ve bu class'ı base class oluşturarak refactor et proje bitince.
        [Key]
        public int Id { get; set; }



        [Display(Name ="Profile Picture")]
        [Required(ErrorMessage ="Profile Picture is required")]
        public string ProfilePictureUrl { get; set; }
        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Full name is required")]
        public string FullName { get; set; }
        [Display(Name = "Biography ")]
        [Required(ErrorMessage = "Biography is required")]
        public string Bio { get; set; }
        //relationships
        public List<Movie> Movies { get; set; }
    }
}
