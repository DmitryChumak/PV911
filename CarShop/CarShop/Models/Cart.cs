using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarShop.Models
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();
        public void AddItem(Car car, int quantity)
        {
            CartLine line = lineCollection
                                .FirstOrDefault(x => x.Car.CarId == car.CarId);
            if (line == null)
            {
                lineCollection.Add(new CartLine
                {
                    Car = car,
                    Quantity = quantity
                });

            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(x => x.Car.Price * x.Quantity);
        }

        public void RemoveLine(Car car)
        {
            lineCollection.RemoveAll(x => x.Car.CarId == car.CarId);
        }
        public void Clear()
        {
            lineCollection.Clear();
        }
        public IEnumerable<CartLine> Lines => lineCollection;
    }
    public class CartLine
    {
        public Car Car { get; set; }
        public int Quantity { get; set; }
    }

}
