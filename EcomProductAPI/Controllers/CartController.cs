using EcomProductAPI.Models;
using EcomProductAPI.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EcomProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartRepository repository;
        private readonly ProductDbContext context;

        public CartController(ICartRepository repository)
        {
            this.repository = repository;
        }
        // GET: api/<CartController>
        [HttpGet]
        public IEnumerable<Cart> Get()
        {
            return (repository.GetCarts());
        }

        // GET api/<CartController>/5
        [HttpGet("{id}")]
        public Cart Get(int id)
        {
            var cart = repository.GetCartById(id);
            return cart;
        }

        // POST api/<CartController>
        [HttpPost]
        public void Post([FromBody] Cart cart)
        {
            repository.AddCart(cart);
            
        }

        // PUT api/<CartController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Cart cart)
        {
            repository.UpdateCart(cart);
        }

        // DELETE api/<CartController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repository.DeleteCartById(id);
        }
    }
}
