using Domain.Core;
using System.Collections.Generic;

namespace BakeryShop.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Pie> PiesOfTheWeek { get; set; }
    }
}
