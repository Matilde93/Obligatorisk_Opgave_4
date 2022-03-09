using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using REST_ObligatoriskOpgave.Models;

namespace REST_ObligatoriskOpgave.Managers
{
    public class CarManager
    {
        private static int _nextId = 1;

        private static List<Car> data = new List<Car>()
        {
            new Car() {Id = _nextId++, Model = "Volvo", LicensePlate = "AC654", Price = 120000},
            new Car() {Id = _nextId++, Model = "Fiat", LicensePlate = "BN457", Price = 89000},
            new Car() {Id = _nextId++, Model = "Kia", LicensePlate = "KL890", Price = 100000},
            new Car() {Id = _nextId++, Model = "Peugeot", LicensePlate = "CB477", Price = 110000},
            new Car() {Id = _nextId++, Model = "Seat", LicensePlate = "AY123", Price = 87000}
        };

        public List<Car> GetAll()
        {
            return new List<Car>(data);
        }

        public Car GetById(int Id)
        {
            return data.Find(car => car.Id == Id);
        }

        public List<Car> FilteredByMaxPrice(double maxPrice)
        {
            var filteredList = new List<Car>();
            foreach (var Car in data)
            {
                if (Car.Price <= maxPrice)
                {
                    filteredList.Add(Car);
                }
            }

            return filteredList;

        }

        public Car AddCar(Car newCar)
        {
            newCar.Id = _nextId++;
            data.Add(newCar);
            return newCar;
        }

        public Car Delete(int id)
        {
            var car = data.Find(car1 => car1.Id == id);
            if (car == null) return null;
            data.Remove(car);
            return car;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
