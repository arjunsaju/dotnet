using EcomProductAPI.DTO;
using EcomProductAPI.Models;

namespace EcomProductAPI.Repository
{
   
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext context;

        public ProductRepository(ProductDbContext context)
        {
            this.context = context;
        }

        //public async Task<Product> AddProduct(Product product)
        //{
        //    var products = await context.Products.AddAsync(product); 
        //    await context.SaveChangesAsync();
        //    return products.Entity;
        //}

        //public async Task<Product> DeleteProduct(int id)
        //{
        //    var products = await context.Products.AddAsync(product);
        //    await context.SaveChangesAsync();
        //    return products.Entity;
        //}

        //public Task<IEnumerable<Product>> GetProduct()
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<Product> GetProduct(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<Product> UpdateProduct(Product product)
        //{
        //    throw new NotImplementedException();
        //}
        public void AddProduct(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
        }

        public void DeleteProductById(int id)
        {
            var product = context.Products.Find(id);
            context.Products.Remove(product);
            context.SaveChanges();
        }

        public ProductDTO GetProductById(int id)
        {
            var prod  = context.Products.Find(id);

            ProductDTO productDTO = new ProductDTO
                {
                    product_id = prod.product_id,
                    product_name = prod.product_name,
                    description = prod.description,
                    image = prod.image,
                    price = prod.price,
                    stock = prod.stock
                };
            return productDTO;
        }

        public List<ProductDTO> GetProducts()
        {
            var product =  context.Products.ToList();

            List<ProductDTO> prodDTO = new List<ProductDTO>();

            foreach(var prod  in product)
            {
                ProductDTO productDTO = new ProductDTO
                {
                    product_id = prod.product_id,
                    product_name = prod.product_name,
                    description= prod.description,
                    image = prod.image,
                    price =prod.price,
                    stock = prod.stock                    
                };

                prodDTO.Add(productDTO);


            }

            return prodDTO;
        }

        public void UpdateProduct(Product product)
        {
            context.Products.Update(product);
            context.SaveChanges();
        }

    }
}
