using SupplementStationDAL.Entities;
using SupplementStationDAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplementStationDAL.Repository
{
    public class CartRepository : ICartRepository
    {
        DataContext _dataContext;
        public CartRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public IEnumerable<CartItem> GetCartItems(int id)
        {
            var res =  _dataContext.CartItems.Include(c => c.ProductSize).ThenInclude(p=>p.Product).Where(c => c.UserId==id).ToList();
            return res; 
        }
        public void AddCartItem(CartItem cartItem)
        {
            _dataContext.CartItems.Add(cartItem);
            _dataContext.SaveChanges();
        }
        public CartItem GetCartItemById(int id)
        {
            return _dataContext.CartItems.FirstOrDefault(p => p.ProductSizeId == id);
        }
        public void UpdateCartItem(int id, int quantity)
        {
            var cartItem = _dataContext.CartItems.FirstOrDefault(p=>p.CartItemId == id);
            cartItem.Quantity = quantity;
            _dataContext.SaveChanges();
        }
        public void DeleteCartItem(int id)
        {
            var cartItem = _dataContext.CartItems.Find(id);
            _dataContext.CartItems.Remove(cartItem);
            _dataContext.SaveChanges();
        }
    }
}
