using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    public class Bus : Vehicle
    {
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public bool IsEmpty { get; set; }

        public override void Driving(double distance)
        {
            double fuelConsumption = distance * FuelConsumption;

            if (!IsEmpty)
            {
                fuelConsumption = distance * (FuelConsumption + 1.4);
            }

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
            if (fuelAmount <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
                return;
            }

            double fuelQuantity = FuelQuantity + fuelAmount;

            if (fuelQuantity > TankCapacity)
            {
                Console.WriteLine($"Cannot fit {fuelAmount} fuel in the tank");
            }
            else
            {
                FuelQuantity += fuelAmount;
            }
        }
    }
}
