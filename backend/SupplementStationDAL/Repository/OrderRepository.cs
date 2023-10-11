using SupplementStationDAL.Entities;
using SupplementStationDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplementStationDAL.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private DataContext _dataContext;
        public OrderRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public int AddOrder(Order order)
        {
            _dataContext.Orders.Add(order);
            _dataContext.SaveChanges();
            return order.OrderId;
        }
        public void AddOrderItems(IEnumerable<OrderItem> items)
        {
            _dataContext.OrderItems.AddRange(items);
            _dataContext.SaveChanges();
        }
        public IEnumerable<Order> GetOrders(int id) { 
            return _dataContext.Orders.Where(p=> p.UserId == id);
        }
        public IEnumerable<OrderItem> GetOrderItems(int? orderId)
        {
            return _dataContext.OrderItems.Where(p=> p.OrderId == orderId);
        }
    }
}
