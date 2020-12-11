using Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BakeryShop.ViewModels
{
    public class DetailsViewModel
    {
        public IEnumerable<Comment> Comments { get; set; }
        public Pie Pie { get; set; }
    }
}
