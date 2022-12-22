using eTheatre.Data;
using eTheatre.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eTheatre.Models
{
    public class Play:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageURL { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public PlayCategory PlayCategory { get; set; }

        public List<Actor_play> Actors_Plays { get; set; }

        //Theatre
        public int TheatreId { get; set; }
        [ForeignKey("TheatreId")]
        public Theatre Theatre { get; set; }

        //Producer
        public int ProducerId { get; set; }
        [ForeignKey("ProducerId")]
        public Producer Producer { get; set; }
    }
}
