using CROMA.API.Data;
using CROMA.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CROMA.API.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly CROMA_DbContext _context;

        public OrderRepository(CROMA_DbContext cROMA_DbContext)
        {
            _context = cROMA_DbContext;
        }
        public async Task<Order> AddOrder(Order order)
        {
            var result = await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteOrder(int OrderId)
        {
            var result = await _context.Orders
                .FirstOrDefaultAsync(o => o.Id == OrderId);

            if (result != null)
            {
                _context.Orders.Remove(result);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Order> GetOrder(int OrderId)
        {
            return await _context.Orders
               .Include(o => o.Car)
               .FirstOrDefaultAsync(o => o.Id == OrderId);
        }

        public async Task<IEnumerable<Order>> GetOrders()
        {
            return await _context.Orders
                 .Include(o => o.Car)
                 .ToListAsync();
        }

        public async Task<Order> UpdateOrder(Order Order)
        {
            var result = await _context.Orders
                  .FirstOrDefaultAsync(o => o.Id == Order.Id);

            if (result != null)
            {
                result.DateFrom = Order.DateFrom;
                result.DateTo = Order.DateTo;
                result.UserName = Order.UserName;
                result.PhoneNumber = Order.PhoneNumber;
                result.Comment = Order.Comment;

                if (Order.CarId != 0)
                {
                    result.CarId = Order.CarId;
                }
                await _context.SaveChangesAsync();

                return result;
            }
            return null;
        }
    }
}