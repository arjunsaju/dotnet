
using EcomProductAPI.DTO;
using EcomProductAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EcomProductAPI.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ProductDbContext context;
        public OrderRepository(ProductDbContext context)
        {
            this.context = context;
        }

        public void AddOrder(Order order)
        {
           
            context.Orders.Add(order);
            context.SaveChanges();
        }

        public void DeleteOrderById(int id)
        {
            var order = context.Orders.Find(id);
            context.Orders.Remove(order);
            context.SaveChanges();
        }

        public Order GetOrderById(int id)
        {
            return context.Orders.Include(o => o.OrderItems).Where(x => x.order_id==id).FirstOrDefault();
        }

        public List<Order> GetOrders()
        {
            return context.Orders.Include(s => s.OrderItems).ToList();
        }

        public void UpdateOrder(Order order)
        {
           
            context.Orders.Update(order);
            context.SaveChanges();
        }
    }
}
