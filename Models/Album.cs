using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace muscshop.Models
{
    public class Album
    {
        [Required(ErrorMessage = "Please, enter the title")]
        public string Title { get; set; }

        [Range(1, 300, ErrorMessage = "please enter price: 1 to 300")]
        public double Price { get; set; }

        public string AlbumUrl { get; set; }

        [Required(ErrorMessage = "ReleaseYear is required")]
        public int ReleaseYear { get; set; }

        public Artist Artist { get; set; }

        public Genre Genre { get; set; }

        public int AlbumId { get; set; }

        public string Description { get; set; } = "albumDescr";

        public int ArtistId { get; set; }

        public int GenreId { get; set; }
    }
}