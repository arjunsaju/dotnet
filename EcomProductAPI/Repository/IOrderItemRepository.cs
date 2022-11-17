using EcomProductAPI.Models;

namespace EcomProductAPI.Repository
{
    public interface IOrderItemRepository
    {
        List<OrderItem> GetOrderItems();
        OrderItem GetOrderItemById(int id);
        void AddOrderItem(OrderItem item);
        void UpdateOrderItem(OrderItem item);
        void DeleteOrderItemById(int id);
        void DeleteOrderItemsByOrderId(int id);

       //void DeleteOrderItemsByProductId(int id);
    }
}
