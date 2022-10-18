using eTickets.Data.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Cinema:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="Cinema Logo")]
        //[Required(ErrorMessage ="Logo is required")]
        public string LogoUrl { get; set; }
        [Display(Name = "Name")]
        //[Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Display(Name = "Cinema Description")]
        //[Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        //Relationships
        public List<Movie> Movies { get; set; }

    }
}
