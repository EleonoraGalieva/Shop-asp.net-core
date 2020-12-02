using Infrastructure.Data;

namespace BakeryShop.ViewModels
{
    public class ShoppingCartViewModel
    {
        public ShoppingCart ShoppingCart { get; set; }
        public decimal Total { set; get; }
    }
}
