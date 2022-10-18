using eTickets.Data.Base;
using eTickets.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eTickets.Models
{
    public class NewMovieVM
    {
        public int Id { get; set; }



        [Display(Name = "Movie Name")]
        [Required(ErrorMessage ="Name is required")]

        public string Name { get; set; }

        [Display(Name = "Movie Description")]
        [Required(ErrorMessage = "Description is required")]

        public string Description { get; set; }

        [Display(Name = "Movie price")]
        [Required(ErrorMessage = "Price is required")]

        public decimal Price { get; set; }

        [Display(Name = "Movie Image")]
        [Required(ErrorMessage = "Image is required")]

        public string ImageUrl { get; set; }

        [Display(Name = "Movie Start Date")]
        [Required(ErrorMessage = "Start date is required")]

        public DateTime StartDate { get; set; }

        [Display(Name = "Movie End Date")]
        [Required(ErrorMessage = "End date is required")]

        public DateTime EndDate { get; set; }

        [Display(Name = "Select a Category")]
        [Required(ErrorMessage = "Movie Category is required")]

        public MovieCategory MovieCategory { get; set; }
        //relationships
        [Display(Name = "Select  movie Actors")]
        [Required(ErrorMessage = "Actor is required")]

        public List<int> ActorIds { get; set; }
        //Cinema
        [Display(Name = "Select a Cinema")]
        [Required(ErrorMessage = "Cinema is required")]

        public int CinemaId { get; set; }
        //Producer
        [Display(Name = "Select a producer")]
        [Required(ErrorMessage = "producer is required")]
        public int ProducerId { get; set; }

    }
}
