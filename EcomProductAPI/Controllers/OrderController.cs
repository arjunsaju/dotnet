
using EcomProductAPI.DTO;
using EcomProductAPI.Models;
using EcomProductAPI.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EcomProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository repository;
        private readonly IOrderItemRepository oitemRepository;


        public OrderController(IOrderRepository repository, IOrderItemRepository oitemRepository)
        {
            this.repository = repository;
            this.oitemRepository = oitemRepository;
        }
        // GET: api/<ValuesController>
        //[HttpGet]
        //public IEnumerable<Order> Get()
        //{
        //    return (repository.GetOrders());
        //}

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public Order Get(int id)
        {
            var order = repository.GetOrderById(id);
            var user = User;

            return order;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] OrderDTO order)
        {
            Order ord = new Order()
            {
                order_date = order.order_date,
                order_status = order.order_status,
                order_total = order.order_total,
                payment_status = order.payment_status,
                user_id = order.user_id
            };

            repository.AddOrder(ord);

            foreach (var ords in order.OrderItemsDTO)
            {
                OrderItem item = new OrderItem()
                {

                    order_id = ord.order_id,                    
                    product_id = ords.product_id,
                    quantity = ords.quantity                   

                };
                oitemRepository.AddOrderItem(item);
            }
        }

        // PUT api/<ValuesController>/5
        [HttpPut]
        public void Put( [FromBody] OrderDTO order)
        {


            Order ord = new Order()
            {
                order_id=order.order_id,
                order_date = order.order_date,
                order_status = order.order_status,
                order_total = order.order_total,
                payment_status = order.payment_status,
                user_id = order.user_id
            };

            repository.UpdateOrder(ord);

            foreach (var ords in order.OrderItemsDTO)
            {
                OrderItem item = new OrderItem()
                {
                    order_item_id = ords.order_item_id,
                    order_id = ords.order_id,                   
                    product_id = ords.product_id,
                    quantity = ords.quantity

                };
                oitemRepository.UpdateOrderItem(item);
            }

        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

           oitemRepository.DeleteOrderItemsByOrderId(id);

            repository.DeleteOrderById(id);

           
          
            

        }
    }
}

