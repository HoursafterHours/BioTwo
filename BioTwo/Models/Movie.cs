using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System;

namespace BioTwo.Models
{
    public class Movie
    {
        public int MovieID { get; set; }
        public string Title { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; } 
        public decimal? Price { get; set; }
        public int Length { get; set; }
        public string Description { get; set; } 

        public Collection<Showing> Showings { get; set; }
    }
}
