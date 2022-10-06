using CROMA.API.Models;
using CROMA.API.Repository;
using Microsoft.AspNetCore.Mvc;


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
                    "Error creating new order record");
            }
        }

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
