using eTheatre.Data.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eTheatre.Models
{
    public class Theatre:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Theatre Logo")]
        [Required(ErrorMessage = "Theatre logo is required")]
        public string Logo { get; set; }

        [Display(Name = "Theatre Name")]
        [Required(ErrorMessage = "Theatre name is required")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Theatre description is required")]
        public string Description { get; set; }


        public List<Play> Plays { get; set; }
    }
}
