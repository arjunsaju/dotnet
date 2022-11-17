using EcomProductAPI.DTO;
using EcomProductAPI.Models;

namespace EcomProductAPI.Repository
{
    public interface IProductRepository
    {
        List<ProductDTO> GetProducts();
        ProductDTO GetProductById(int id);
        void DeleteProductById(int id);

        void UpdateProduct(Product product);
        void AddProduct(Product product);

        //Task<IEnumerable<Product>> GetProduct();
        //Task<Product> GetProduct(int id);
        //Task<Product> AddProduct(Product product);
        //Task<Product> UpdateProduct(Product product);

        //void DeleteProduct(int id);

    }
}
