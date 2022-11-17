using EcomProductAPI.Models;

namespace EcomProductAPI.Repository
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly ProductDbContext context;

        public OrderItemRepository(ProductDbContext context)
        {
            this.context = context;
        }

        public void AddOrderItem(OrderItem item)
        {
            context.OrdersItem.Add(item);
            context.SaveChanges();
        }

        public void DeleteOrderItemById(int id)
        {
            var item = context.OrdersItem.Find(id);
            context.OrdersItem.Remove(item);
            context.SaveChanges();
        }
        public void DeleteOrderItemsByOrderId(int id)
        {
            var items = context.OrdersItem.Where(x => x.order_id == id);
            context.OrdersItem.RemoveRange(items);
            context.SaveChanges();
        }

        //public void DeleteOrderItemsByProductId(int id)
        //{
        //    var items = context.OrdersItem.Where(x => x.product_id == id);
        //    context.OrdersItem.RemoveRange(items);
        //    context.SaveChanges();
        //}

       

        public OrderItem GetOrderItemById(int id)
        {
            return context.OrdersItem.Find(id);
        }

        public List<OrderItem> GetOrderItems()
        {
            return context.OrdersItem.ToList();
        }

        public void UpdateOrderItem(OrderItem item)
        {
            context.OrdersItem.Update(item);
            context.SaveChanges();
        }
    }
}
