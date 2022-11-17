
using EcomProductAPI.Models;

namespace EcomProductAPI.Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly ProductDbContext context;
        public CartRepository(ProductDbContext context)
        {
            this.context = context;
        }

        public void AddCart(Cart cart)
        {
           context.Carts.Add(cart);
            context.SaveChanges();
        }

        public void DeleteCartById(int id)
        {
            var cart = context.Carts.Find(id);
            context.Carts.Remove(cart);
            context.SaveChanges();
        }

        //public void DeleteCartByProductId(int id)
        //{
        //    var items = context.OrdersItem.Where(x => x.product_id == id);
        //    context.OrdersItem.RemoveRange(items);
        //    context.SaveChanges();
        //}

        public Cart GetCartById(int id)
        {
            return context.Carts.Find(id);
        }

        public List<Cart> GetCarts()
        {
            return context.Carts.ToList();
        }

        public void UpdateCart(Cart cart)
        {
            context.Carts.Update(cart);
            context.SaveChanges();
        }
    }
}
