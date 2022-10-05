using CROMA.API.Models;
using CROMA.API.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CROMA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }
        // GET: api/<OrderController>
        [HttpGet]
        public async Task<ActionResult> GetOrders()
        {
            try
            {
                return Ok(await orderRepository.GetOrders());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        // GET api/<OrderController>/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            var result = await orderRepository.GetOrder(id);

            if (result == null)
            {
                return NotFound();
            }

            return result;
        }

        // POST api/<OrderController>
        [HttpPost]
        public async Task<ActionResult<Order>> AddOrder([FromBody] Order order)
        {
            try
            {
                if (order == null)
                    return BadRequest();

                var addOrder = await orderRepository.AddOrder(order);

                return CreatedAtAction(nameof(GetOrder),
                    new { id = addOrder.Id }, addOrder);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new Order record");
            }
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Order>> UpdateOrder(int id, [FromBody] Order order)
        {
            try
            {
                if (id != order.Id)
                    return BadRequest("Order ID Mismatch");

                var orderToUpdate = await orderRepository.GetOrder(id);

                if (orderToUpdate == null)
                {
                    return NotFound($"Order with Id = {id} not found");
                }

                return await orderRepository.UpdateOrder(order);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating Order record");
            }
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOder(int id)
        {
            try
            {
                var orderToDelete = await orderRepository.GetOrder(id);

                if (orderToDelete == null)
                {
                    return NotFound($"Order with Id = {id} not found");
                }

                await orderRepository.DeleteOrder(id);

                return Ok($"Order with Id = {id} deleted");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting order record");
            }
        }
    }
}
