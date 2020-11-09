using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double fuelConsumption)
            : base(fuelQuantity, fuelConsumption)
        {
        }

        public override void Driving(double distance)
        {
            double fuelConsumption = distance * (FuelConsumption + 0.9);

            if (fuelConsumption > FuelQuantity)
            {
                Console.WriteLine($"{GetType().Name} needs refueling");
            }
            else
            {
                FuelQuantity -= fuelConsumption;
                Console.WriteLine($"{GetType().Name} travelled {distance} km");
            }
        }

        public override void Refueling(double fuelAmount)
        {
            FuelQuantity += fuelAmount;
        }
    }
}
