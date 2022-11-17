using EcomProductAPI.Models;

namespace EcomProductAPI.Repository
{
    public interface ICartRepository
    {
        List<Cart> GetCarts();
        Cart GetCartById(int id);
        void AddCart(Cart cart);
        void UpdateCart(Cart cart);
        void DeleteCartById(int id);

        //void DeleteCartByProductId(int id);


    }
}
