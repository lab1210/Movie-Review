using Movie_App.Resources;
using Movie_App.Service;
using Movie_App.Models;
using System;
using System.Linq;
using System.Web.Mvc;
using PagedList;
using Movie_App.IService;
using System.Drawing.Printing;
using System.Web.UI;
using System.Web;

namespace Movie_App.Controllers
{
    public class HomeController : Controller
    {
        private readonly MovieService movieService;
        private readonly SeriesService seriesService;

        public HomeController()
        {
            movieService = new MovieService();
            seriesService = new SeriesService();


        }


        
        public ActionResult Movie(int? page, string searchname = " ")
        {
            ViewBag.genre = movieService.GetGenres();
            ViewBag.country = movieService.GetCountry();

            var search = movieService.MovieSearch();

            search = search.Where(x => x.Name.ToLower().Contains(searchname.ToLower()));



            var loggedInUserName = HttpContext.Session["LoggedInUserName"] as string;
            ViewBag.LoggedInUserName = loggedInUserName;
            var userrole = HttpContext.Session["UserRole"] as string;
            ViewBag.UserRole = userrole;

            var highrate = movieService.GetMovieWithHighestRating();
            ViewBag.Highrate = highrate;

            int pagesize = 4;
            int total = search.Count();
            int totalpages = (int)Math.Ceiling((double)total / pagesize);
            int currentPage = page ?? 1;
            currentPage = Math.Max(1, Math.Min(currentPage, totalpages));

            search = search.Skip((currentPage - 1) * pagesize).Take(pagesize);
            ViewBag.TotalPages = totalpages;
            ViewBag.CurrentPage = currentPage;
            return View(search);



        }


        public ActionResult TVSeries(int? page, string searchname = "")
        {
            var search = seriesService.Search();
            ViewBag.country = seriesService.GetCountry();

            ViewBag.genre = seriesService.GetGenres();

            if (!string.IsNullOrEmpty(searchname))
            {
                search = search.Where(x => x.Name.ToLower().Contains(searchname.ToLower()));

            }
            var loggedInUserName = HttpContext.Session["LoggedInUserName"] as string;
            ViewBag.LoggedInUserName = loggedInUserName;
            var userrole = HttpContext.Session["UserRole"] as string;

            ViewBag.UserRole = userrole;
            var highrate = seriesService.GetSeriesWithHighRating();
            ViewBag.Highrate = highrate;

            int pagesize = 4;
            int total = search.Count();
            int totalpages = (int)Math.Ceiling((double)total / pagesize);
            int currentPage = page ?? 1;
            currentPage = Math.Max(1, Math.Min(currentPage, totalpages));

            search = search.Skip((currentPage - 1) * pagesize).Take(pagesize);
            ViewBag.TotalPages = totalpages;
            ViewBag.CurrentPage = currentPage;
            return View(search);
        }


        public ActionResult Movie_Genre(string genreName, int? page)
        {
            ViewBag.country = movieService.GetCountry();

            ViewBag.genre = movieService.GetGenres();
            var movies=movieService.GetMovieByGenre(genreName);
            ViewBag.name = genreName;
            int pagesize = 4;
            int total = movies.Count();
            int totalpages = (int)Math.Ceiling((double)total / pagesize);
            int currentPage = page ?? 1;
            currentPage = Math.Max(1, Math.Min(currentPage, totalpages));

            movies = movies.Skip((currentPage - 1) * pagesize).Take(pagesize);
            ViewBag.TotalPages = totalpages;
            ViewBag.CurrentPage = currentPage;
            return View(movies);

        }
        public ActionResult Movie_Country(string countryName,int?page)
        {
            ViewBag.genre = movieService.GetGenres();

            ViewBag.country = movieService.GetCountry();
            var movies = movieService.GetMovieByCountry(countryName);
            ViewBag.name = countryName;
            int pagesize = 4;
            int total = movies.Count();
            int totalpages = (int)Math.Ceiling((double)total / pagesize);
            int currentPage = page ?? 1;
            currentPage = Math.Max(1, Math.Min(currentPage, totalpages));

            movies = movies.Skip((currentPage - 1) * pagesize).Take(pagesize);
            ViewBag.TotalPages = totalpages;
            ViewBag.CurrentPage = currentPage;
            return View(movies);

        }

        public ActionResult Series_Country(string countryName, int? page)
        {
            ViewBag.genre = seriesService.GetGenres();

            ViewBag.country = seriesService.GetCountry();
            var movies = seriesService.GetSeriesByCountry(countryName);
            ViewBag.name = countryName;
            int pagesize = 4;
            int total = movies.Count();
            int totalpages = (int)Math.Ceiling((double)total / pagesize);
            int currentPage = page ?? 1;
            currentPage = Math.Max(1, Math.Min(currentPage, totalpages));

            movies = movies.Skip((currentPage - 1) * pagesize).Take(pagesize);
            ViewBag.TotalPages = totalpages;
            ViewBag.CurrentPage = currentPage;
            return View(movies);

        }
        public ActionResult Series_Genre(string genreName, int? page)
        {
            ViewBag.genre = seriesService.GetGenres();
            ViewBag.country = seriesService.GetCountry();

            var movies = seriesService.GetSeriesByGenre(genreName);
            ViewBag.name = genreName;
            int pagesize = 4;
            int total = movies.Count();
            int totalpages = (int)Math.Ceiling((double)total / pagesize);
            int currentPage = page ?? 1;
            currentPage = Math.Max(1, Math.Min(currentPage, totalpages));

            movies = movies.Skip((currentPage - 1) * pagesize).Take(pagesize);
            ViewBag.TotalPages = totalpages;
            ViewBag.CurrentPage = currentPage;
            return View(movies);
        }

        public ActionResult SeriesDetails(string slug)
        {
            ViewBag.genre = seriesService.GetGenres();
            ViewBag.country = seriesService.GetCountry();


            SeriesResources movie = seriesService.GetSeriesByCode(slug);
            var loggedInUserName = HttpContext.Session["LoggedInUserName"] as string;
            ViewBag.LoggedInUserName = loggedInUserName;
            var userrole = HttpContext.Session["UserRole"] as string;
            ViewBag.UserRole = userrole;
            var rate = seriesService.GetSeriesRating(slug);
            ViewBag.Rate = rate;

            return View(movie);

        }
        public ActionResult MovieDetails(string slug)
        {
            ViewBag.country = movieService.GetCountry();

            ViewBag.genre = movieService.GetGenres();

            MovieResources movie = movieService.GetMovieByCode(slug);
            var loggedInUserName = HttpContext.Session["LoggedInUserName"] as string;
            ViewBag.LoggedInUserName = loggedInUserName;
            var userrole = HttpContext.Session["UserRole"] as string;
            ViewBag.UserRole = userrole;
            var rate = movieService.GetRatingAverage(slug);
            ViewBag.Rate = rate;

            return View(movie);


        }
        [HttpPost]
        public ActionResult AddRating(MovieResources model)
        {

            var loggedInUserName = HttpContext.Session["LoggedInUserName"] as string;
            var rate = new Rating
            {
                UserName = loggedInUserName,
                MovieID = model.Id,
                Slug = model.Slug,
                Value = model.NewRating.Value,

            };
            movieService.AddOrUpdateRating(rate.MovieID, rate.Value, rate.UserName, rate.Slug);
            return RedirectToAction("MovieDetails", new { slug = model.Slug });

        }
        [HttpPost]
        public ActionResult AddRatingforseries(SeriesResources model)
        {

            var loggedInUserName = HttpContext.Session["LoggedInUserName"] as string;
            var rate = new SeriesRatings
            {
                UserName = loggedInUserName,
                SeriesID = model.Id,
                Slug = model.Slug,
                Value = model.NewSeriesRating.Value,

            };
            seriesService.AddOrUpdateSeriesRating(rate.SeriesID, rate.Value, rate.UserName, rate.Slug);
            return RedirectToAction("SeriesDetails", new { slug = model.Slug });

        }

        [HttpPost]
        public ActionResult AddComment(MovieResources model)
        {

            var loggedInUserName = HttpContext.Session["LoggedInUserName"] as string;

            var comment = new MovieComment
            {
                User = loggedInUserName,
                Post = model.NewCommentresource.Post,
                PostDate = DateTime.Now,
                MovieId = model.Id,
                Slug = model.Slug,

            };

            movieService.AddComment(comment.MovieId, comment.User, comment.Post, comment.Slug);


            return RedirectToAction("MovieDetails", new { slug = model.Slug });
        }

        [HttpPost]
        public ActionResult AddCommentforseries(SeriesResources model)
        {

            var loggedInUserName = HttpContext.Session["LoggedInUserName"] as string;

            var comment = new SeriesComment
            {
                User = loggedInUserName,
                Post = model.NewCommentresource.Post,
                PostDate = DateTime.Now,
                SeriesId = model.Id,
                Slug = model.Slug,
            };

            seriesService.AddCommentForSeries(comment.SeriesId, comment.User, comment.Post, comment.Slug);


            return RedirectToAction("SeriesDetails", new { slug = model.Slug });
        }




    }
}




