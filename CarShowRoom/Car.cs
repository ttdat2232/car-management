using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShowRoom
{
    public class Car
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }


        public Car(string code, string name, string brand, decimal price)
        {
            Code = code;
            Name = name;
            Brand = brand;
            Price = price;
        }

        public Car() { }
    }
}
