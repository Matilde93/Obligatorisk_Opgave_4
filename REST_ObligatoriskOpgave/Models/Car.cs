using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST_ObligatoriskOpgave.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string LicensePlate { get; set; }
        public double Price { get; set; }

        public Car()
        {
            
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
