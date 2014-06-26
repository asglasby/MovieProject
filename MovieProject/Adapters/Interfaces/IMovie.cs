using MovieProject.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieProject.Adapters.Interfaces
{
    public interface IMovie
    {
        Movie GetMovie(int id);
        List<Movie> GetMovies();
        int CreateMovie(Movie movie);
        void UpdateMovie(int id, Movie movie);
        void DeleteMovie(int id);
    }
}
