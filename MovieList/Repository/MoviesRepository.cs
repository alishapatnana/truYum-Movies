using MovieList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieList.Repository
{
    public class MoviesRepository : IMoviesRepository<Movies>
    {
        static List<Movies> _movies;
        static MoviesRepository()
        {
            _movies = new List<Movies>(){
                new Movies() {  MovieId=1001,MovieName = "The Princess Switch", Active=true, Price=255, DateOfLaunch=DateTime.Parse("11-16-2018"),GenreType="Romance,Comedy",HasTeaser=true},
                new Movies() {  MovieId=1002,MovieName = "The Princess Switch Again", Active=true, Price=120, DateOfLaunch=DateTime.Parse("11-19-2020"),GenreType="Romance,Comedy",HasTeaser=true},
                new Movies() {  MovieId=1003,MovieName = "After", Active=true, Price=130, DateOfLaunch=DateTime.Parse("04-11-2019"),GenreType="Romance,Young Adult",HasTeaser=true},
            };
        }

        public void Add(Movies item)
        {
            _movies.Add(item);
        }

        public bool Delete(int id)
        {
            var movieitem = _movies.FirstOrDefault(m => m.MovieId == id);
            var IsDeleted = _movies.Remove(movieitem);
            return IsDeleted;
        }

        public IEnumerable<Movies> GetAll()
        {
            return _movies;
        }

        public Movies GetById(int id)
        {
            var movieitem = _movies.FirstOrDefault(m => m.MovieId == id);
            return movieitem;
        }

        public Movies Update(Movies item)
        {
            var updatemenuitem = _movies.FirstOrDefault(m => m.MovieId == item.MovieId);

            updatemenuitem.MovieName = item.MovieName;
            updatemenuitem.DateOfLaunch = item.DateOfLaunch;
            updatemenuitem.Active = item.Active;
            updatemenuitem.GenreType = item.GenreType;
            updatemenuitem.HasTeaser = item.HasTeaser;
            updatemenuitem.Price = item.Price;
            return updatemenuitem;
        }
    }
}
