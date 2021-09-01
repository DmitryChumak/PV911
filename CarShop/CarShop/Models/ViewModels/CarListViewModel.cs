using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarShop.Models.ViewModels
{
    public class CarListViewModel
    {
        public SelectList Companies { get; set; }
        public List<Car> Cars { get; set; }
    }
}
