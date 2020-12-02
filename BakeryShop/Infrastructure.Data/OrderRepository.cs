using Domain.Core;
using Domain.Interfaces;
using System;

namespace Infrastructure.Data
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly ShoppingCart _shoppingcart;
        public OrderRepository(AppDbContext appDbContext, ShoppingCart shoppingCart)
        {
            _appDbContext = appDbContext;
            _shoppingcart = shoppingCart;
        }
        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;
            _appDbContext.Orders.Add(order);
            var shoppingCartItems = _shoppingcart.GetShoppingCartItems();
            foreach (var item in shoppingCartItems)
            {
                var orderDetail = new OrderDetail
                {
                    Pie = item.Pie,
                    Amount = item.Amount,
                    Price = item.Pie.Price,
                    PieId = item.Pie.PieId,
                    OrderId = order.OrderId
                };
            }
            _appDbContext.SaveChanges();
        }
    }
}
