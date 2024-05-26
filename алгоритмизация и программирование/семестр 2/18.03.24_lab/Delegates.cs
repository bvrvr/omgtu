using System;
using System.Collections.Generic;

namespace Delegates
{
    public class Car
    {
        public string CarMake { get; set; }

        public Car(string carMake)
        {
            CarMake = carMake;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Машина марки: {CarMake}");
        }
    }
    public class CarWash
    {
        public void Wash(Car car)
        {
            Console.WriteLine($"Мытьё машины марки: {car.CarMake}");
        }
    }
    public class Garage
    {
        public List<Car> Cars { get; set; }

        public Garage()
        {
            Cars = new List<Car>();
        }

        public void AddCar(Car car)
        {
            Cars.Add(car);
        }

        public delegate void CarWashDelegate(Car car);

        public void WashAllCars(CarWashDelegate carWashDelegate)
        {
            foreach (var car in Cars)
            {
                carWashDelegate(car);
            }
        }
    }
    internal class Delegates
    {
        static void Main(string[] args)
        {
            Car car1 = new Car("LADA");
            Car car2 = new Car("Toyota");
            Car car3 = new Car("Nissan");

            Garage garage = new Garage();
            garage.AddCar(car1);
            garage.AddCar(car2);
            garage.AddCar(car3);

            CarWash carWash = new CarWash();

            Garage.CarWashDelegate carWashDelegate = new Garage.CarWashDelegate(carWash.Wash);

            garage.WashAllCars(carWashDelegate);
        }
    }
}
