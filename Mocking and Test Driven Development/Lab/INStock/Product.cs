using System;

namespace INStock
{
    public class Product
    {
        private string label;
        private decimal price;
        private int quantity;

        public Product(string label, decimal price, int quantity)
        {
            Label = label;
            Price = price;
            Quantity = quantity;
        }

        public string Label
        {
            get
            {
                return label;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Label should not be empty or whitespace!");
                }

                label = value;
            }
        }
        public decimal Price
        {
            get
            {
                return price;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price should be positive!");
                }

                price = value;
            }
        }
        public int Quantity
        {
            get
            {
                return quantity;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Quantity should not be negative!");
                }

                quantity = value;
            }
        }
    }
}
