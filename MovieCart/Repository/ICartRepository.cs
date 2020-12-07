using MovieCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCart.Repository
{
    public interface ICartRepository
    {
        Movies AddToCart(int userId, Movies item);

        IEnumerable<Movies> GetCartItems(int UserId);
        bool Delete(int UserId, int itemI);

    }
}
