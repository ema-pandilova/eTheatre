using eTheatre.Data;
using eTheatre.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eTheatre.Models
{
    public class NewPlayVM
    {
        public int Id { get; set; }
        [Display(Name = "Play name")]
        [Required(ErrorMessage ="Name is required")]
        public string Name { get; set; }
        [Display(Name = "Play description")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        [Display(Name = "Price in $")]
        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }
        [Display(Name = "Play poster URL")]
        [Required(ErrorMessage = "Play poster URL is required")]
        public string ImageURL { get; set; }
        [Display(Name = "Play start date")]
        [Required(ErrorMessage = "Start date is required")]
        public DateTime StartDate { get; set; }
        [Display(Name = "Play end date")]
        [Required(ErrorMessage = "End date is required")]
        public DateTime EndDate { get; set; }
        [Display(Name = "Select a category")]
        [Required(ErrorMessage = "Category is required")]
        public PlayCategory PlayCategory { get; set; }
        [Display(Name = "Select actor(s)")]
        [Required(ErrorMessage = "Play actor(s) is required")]
        public List<int> ActorIds { get; set; }

        [Display(Name = "Select a theatre")]
        [Required(ErrorMessage = "Theatre is required")]
        public int TheatreId { get; set; }

        [Display(Name = "Select a producer")]
        [Required(ErrorMessage = "Producer is required")]

        public int ProducerId { get; set; }
        
    }
}
