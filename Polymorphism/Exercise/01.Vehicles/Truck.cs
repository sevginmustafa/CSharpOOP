using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumption)
            : base(fuelQuantity, fuelConsumption)
        {
        }

        public override void Driving(double distance)
        {
            double fuelConsumption = distance * (FuelConsumption + 1.6);

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
            FuelQuantity += fuelAmount * 0.95;
        }
    }
}
