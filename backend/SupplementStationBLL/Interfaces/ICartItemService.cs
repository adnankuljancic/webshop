using SupplementStationBLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplementStationBLL.Interfaces
{
    public interface ICartItemService
    {
        List<CartItemDto> GetCartItems(int id);
        void AddCartItem(CartItemDto cartItem);
        void UpdateCartItem(int id, int quantity);
        void DeleteCartItem(int id);
    }
}
