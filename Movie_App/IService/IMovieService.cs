using Movie_App.Models;
using Movie_App.Resources;
using System.Collections.Generic;

namespace Movie_App.IService
{
    public interface IMovieService
    {
        bool AddMovie(MovieResources movie);
        IEnumerable<MovieResources> GetAllMovies();
        IEnumerable<MovieResources> MovieSearch();

        MovieResources Getgenredetails();
        MovieResources GetMovieById(int id);
        MovieResources GetMovieByCode(string Slug);
        void UpdateMovie(MovieResources movie);
        void DeleteMovie(int id);

        void AddComment(int movieId, string user, string post, string slug);
        void AddOrUpdateRating(int movieid, int ratingvalue, string user, string slug);

        decimal GetRatingAverage(string slug);
        IEnumerable<Movie> GetMovieWithHighestRating();
        IEnumerable<string> GetGenres();
        IEnumerable<MovieResources> GetMovieByGenre(string genreName);
        IEnumerable<MovieResources> GetMovieByCountry(string countryName);
        IEnumerable<string> GetCountry();





    }
}
