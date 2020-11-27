using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INStock
{
    public class ProductStock
    {
        private List<Product> products;

        public ProductStock()
        {
            products = new List<Product>();
        }

        public int Count => products.Count;

        public void Add(Product product)
        {
            if (products.Any(x => x.Label == product.Label))
            {
                throw new InvalidOperationException("Product is already in the stock");
            }

            products.Add(product);
        }

        public bool Contains(Product product)
        {
            return products.Any(x => x.Label == product.Label);
        }

        public Product Find(int index)
        {
            if (!(index - 1 >= 0 && index - 1 < products.Count))
            {
                throw new IndexOutOfRangeException("Index was outside the bounds of the array");
            }

            return products[index - 1];
        }

        public Product FindByLabel(string label)
        {
            if (!products.Any(x => x.Label == label))
            {
                throw new ArgumentException("Such product doesn't exist");
            }

            return products.First(x => x.Label == label);
        }

        public Product[] FindAllInPriceRange(decimal startPrice, decimal endPrice)
        {
            return products.FindAll(x => x.Price >= startPrice && x.Price <= endPrice).
            OrderByDescending(x => x.Price).ToArray();
        }

        public Product[] FindAllByPrice(decimal price)
        {
            return products.FindAll(x => x.Price == price).ToArray();
        }

        public Product FindMostExpensiveProducts()
        {
            return products.OrderByDescending(x => x.Price).First();
        }

        public Product[] FindAllByQuantity(int quantity)
        {
            return products.FindAll(x => x.Quantity == quantity).ToArray();
        }

        public Product[] GetEnumerator()
        {
            return products.ToArray();
        }
    }
}
