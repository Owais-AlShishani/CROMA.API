using CROMA.API.Models;

namespace CROMA.API.Repository
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetOrders();
        Task<Order> GetOrder(int OrderId);
        Task<Order> AddOrder(Order Order);
        Task<Order> UpdateOrder(Order Order);
        Task DeleteOrder(int OrderId);
    }
}
