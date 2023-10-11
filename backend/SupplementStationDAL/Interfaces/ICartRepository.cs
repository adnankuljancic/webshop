using SupplementStationDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplementStationDAL.Interfaces
{
    public interface ICartRepository
    {
        IEnumerable<CartItem> GetCartItems(int id);
        void AddCartItem(CartItem cartItem);
        CartItem GetCartItemById(int id);
        void UpdateCartItem(int id, int quantity);
        void DeleteCartItem(int id);
    }
}
