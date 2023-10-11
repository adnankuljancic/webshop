using SupplementStationDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplementStationDAL.Interfaces
{
    public interface IOrderRepository
    {
        int AddOrder(Order order);
        void AddOrderItems(IEnumerable<OrderItem> items);
        IEnumerable<Order> GetOrders(int id);
        IEnumerable<OrderItem> GetOrderItems(int? orderId);


    }
}
