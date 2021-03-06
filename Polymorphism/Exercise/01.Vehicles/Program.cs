﻿using System;

namespace _01.Vehicles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine().Split();
            string[] truckInfo = Console.ReadLine().Split();

            Vehicle car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]));
            Vehicle truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]));

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split();

                if (command[0] == "Drive")
                {
                    if (command[1] == "Car")
                    {
                        car.Driving(double.Parse(command[2]));
                    }
                    else
                    {
                        truck.Driving(double.Parse(command[2]));
                    }
                }
                else
                {
                    if (command[1] == "Car")
                    {
                        car.Refueling(double.Parse(command[2]));
                    }
                    else
                    {
                        truck.Refueling(double.Parse(command[2]));
                    }
                }
            }

            Console.WriteLine($"Car: {Math.Round(car.FuelQuantity,2):f2}");
            Console.WriteLine($"Truck: {Math.Round(truck.FuelQuantity,2):f2}");
        }
    }
}
