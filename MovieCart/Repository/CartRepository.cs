using MovieCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCart.Repository
{
    public class CartRepository : ICartRepository
    {
        static Dictionary<int, List<Movies>> _items;
        static CartRepository()
        {
            _items = new Dictionary<int, List<Movies>>();
        }
        public Movies AddToCart(int userId, Movies item)
        {
            foreach (var items in _items.Keys)
            {
                if (items == userId)
                {
                    _items[userId].Add(item);
                    return item;
                }
            }
            _items.Add(userId, new List<Movies>());
            _items[userId].Add(item);
            return item;
        }


        public IEnumerable<Movies> GetCartItems(int id)
        {
            return _items[id];
        }
        public bool Delete(int userid, int menuitemid)
        {
            var cartItems = _items[userid];

            var item = cartItems.FirstOrDefault(c => c.MovieId == menuitemid);
            return cartItems.Remove(item);
        }
    }
}