using Domain.Core;

namespace Domain.Interfaces
{
    public interface IOrderRepository
    {
        public void CreateOrder(Order order);
    }
}
