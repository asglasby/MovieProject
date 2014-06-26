using MovieProject.Adapters.Interfaces;
using MovieProject.Data;
using MovieProject.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieProject.Adapters.Adapters
{
    public class MovieAdapter : IMovie
    {
        public Movie GetMovie(int id)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            return db.Movies.Where(m => m.Id == id).FirstOrDefault();
        }

        public List<Movie> GetMovies()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            return db.Movies.ToList();
        }

        public int CreateMovie(Movie movie)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            db.Movies.Add(movie);
            db.SaveChanges();
            return movie.Id;
        }

        public void UpdateMovie(int id, Movie movie)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            Movie dbMovie = db.Movies.Where(m => m.Id == id).FirstOrDefault();
            dbMovie.Title = movie.Title;
            dbMovie.Summary = movie.Summary;
            dbMovie.ImageUrl = movie.ImageUrl;
            db.SaveChanges();
        }

        public void DeleteMovie(int id)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            Movie movie = db.Movies.Where(m => m.Id == id).FirstOrDefault();
            db.Movies.Remove(movie);
            db.SaveChanges();
        }
    }
}