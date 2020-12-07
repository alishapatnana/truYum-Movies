using MovieList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieList.Repository
{
   public  interface IMoviesRepository<T>
   {
        IEnumerable<Movies> GetAll();
        T GetById(int id);
        void Add(T item);
        T Update(T item);
        bool Delete(int id);

    }
}
