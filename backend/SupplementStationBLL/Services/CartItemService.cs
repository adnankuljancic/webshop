using AutoMapper;
using SupplementStationBLL.DTO;
using SupplementStationBLL.Interfaces;
using SupplementStationDAL.Entities;
using SupplementStationDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplementStationBLL.Services
{
    public class CartItemService : ICartItemService
    {
        private ICartRepository _cartRepository;
        private IMapper _mapper;
        public CartItemService(ICartRepository cartRepository, IMapper mapper)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;
        }
        public List<CartItemDto> GetCartItems(int id)
        {
            var res = _cartRepository.GetCartItems(id);
            var product = _mapper.Map<List<CartItemDto>>(res);
            return product;
        }
        public void AddCartItem(CartItemDto cartItem)
        {
            var item = _mapper.Map<CartItem>(cartItem);
            _cartRepository.AddCartItem(item);
        }
        public void UpdateCartItem(int id, int quantity)
        {
            _cartRepository.UpdateCartItem(id, quantity);

        }
        public void DeleteCartItem(int id)
        {
            _cartRepository.DeleteCartItem(id);
        }
    }
}
