using EcomProductAPI.DTO;
using EcomProductAPI.Models;

namespace EcomProductAPI.Repository
{
    public interface IOrderRepository
    {
        List<Order>GetOrders();
        
        Order GetOrderById(int id);
        void AddOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrderById(int id);
        
    }
}
