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
    public class OrderService : IOrderService
    {
        private IOrderRepository _orderRepositoy;
        private IMapper _mapper;
        public OrderService(IOrderRepository orderRepositoy, IMapper mapper)
        {
            _orderRepositoy = orderRepositoy;
            _mapper = mapper;
        }

        public void AddOrder(OrderDto order)
        {
            var orderMapped = _mapper.Map<Order>(order);
            var id = _orderRepositoy.AddOrder(orderMapped);
            var orderSizesMapped = _mapper.Map <List<OrderItem>>(order.orderItemsList);
            orderSizesMapped.ForEach(_ => _.OrderId= id);
            _orderRepositoy.AddOrderItems(orderSizesMapped);
        }
        public IEnumerable<OrderDto> GetAllOrders(int userId)
        {
            var orderList = _mapper.Map<List<OrderDto>>(_orderRepositoy.GetOrders(userId));
            orderList.ForEach(order => { order.orderItemsList = _mapper.Map<List<OrderItemDto>>(_orderRepositoy.GetOrderItems(order.OrderId)); });
            return orderList;
        }
    }
}
