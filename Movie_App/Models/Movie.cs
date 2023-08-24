﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Movie_App.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public int Code { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
        [Required]

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [Range(0, double.PositiveInfinity)]

        public decimal TicketPrice { get; set; }

        public string Country { get; set; }

        public string ImagePath { get; set; }
        public string VideoPath { get; set; }

        public string Slug { get; set; }
        public List<PickedGenre> SelectedGenres { get; set; }
        public virtual List<MovieComment> MovieComments { get; set; }

        public MovieComment NewComment { get; set; }
        public virtual List<Rating> Ratings { get; set; }
        public Rating NewRating { get; set; }



    }
    public class PickedGenre
    {
        public int id { get; set; }
        public string name { get; set; }
        public int genreid { get; set; }
        public Genre Genre { get; set; }

        public bool Selected { get; set; } = false;

    }
   
    public class MovieComment
    {
        public int Id { get; set; }
        public string User { get; set; }
        [Required]
        public string Post { get; set; }

        [DataType(DataType.Date)]
        public DateTime PostDate { get; set; } = DateTime.Now;
        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; }
        public string Slug { get; set; }

    }
    public class Rating
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public int MovieID { get; set; }
        public virtual Movie Movie { get; set; }
        public string UserName { get; set; }
        public string Slug { get; set; }
    }


}
