﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Cake : Dessert
    {
        public Cake(string name) : base(name, DefaultCakePrice, DefaultGrams, DefaultCalories)
        {

        }

        private const double DefaultGrams = 250;
        private const double DefaultCalories = 1000;
        private const decimal DefaultCakePrice = 5m;
    }
}
