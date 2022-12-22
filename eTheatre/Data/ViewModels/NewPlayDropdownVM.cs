using eTheatre.Models;
using System.Collections.Generic;

namespace eTheatre.Data.ViewModels
{
    public class NewPlayDropdownVM
    {
        public NewPlayDropdownVM()
        {
            Producers = new List<Producer>();
            Theatres = new List<Theatre>();
            Actors = new List<Actor>();
        }
        public List<Producer> Producers { get; set; }
        public List<Theatre> Theatres { get; set; }
        public List<Actor> Actors { get; set; }
    }
}
