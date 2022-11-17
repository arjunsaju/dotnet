using EcomProductAPI.DTO;
using EcomProductAPI.Models;
using EcomProductAPI.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EcomProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository repository;
        //private readonly IOrderItemRepository oitemRepository;
        //private readonly ICartRepository cRepository;


        //private readonly ProductDbContext context;

        public ProductController(IProductRepository repository )
        {
            this.repository = repository;
            //this.oitemRepository = oitemRepository;
            //this.cRepository = cRepository;
        }
        
        //{
        //    this.context = context;
        //}
        // GET: api/<ProductController>
        [HttpGet]
        public IEnumerable<ProductDTO> Get()
        {
            return repository.GetProducts();
            //return context.Products.ToList();
           
        }

        // GET api/<ProductController>/5

        [HttpGet("{id}")]
        //[Route("Api/ListProduct")]
        public ProductDTO GetProduct(int id)
        {
            var product = repository.GetProductById(id);            

            return product;
        }

        // POST api/<ProductController>
        [HttpPost]
        public void Post([FromBody] ProductDTO product)
        {
            Product pro = new Product()
            {
                product_name = product.product_name,
                description = product.description,
                stock = product.stock,
                price = product.price,
                image = product.image
            };

            repository.AddProduct(pro);

           
        }

        // PUT api/<ProductController>/5
        [HttpPut]
        public void Put(  [FromBody] ProductDTO product)
        {
            Product pro = new Product()
            {
                product_id = product.product_id,
                product_name = product.product_name,
                description = product.description,
                stock = product.stock,
                price = product.price,
                image = product.image
            };

            repository.UpdateProduct(pro);
            
            
            
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

          
            repository.DeleteProductById(id);
            
        }
    }
}
