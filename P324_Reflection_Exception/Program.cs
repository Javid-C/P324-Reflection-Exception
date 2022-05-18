using System;
using System.Collections.Generic;

namespace P324_Reflection_Exception
{
    class Program
    {
        static void Main(string[] args)
        {
            Product product = new Product("Milk",1,12.9d);
            Product product1 = new Product("Milk",10,10.2d);
            Product product2 = new Product("Milk",3,18.32d);
            Product product3 = new Product("Milk",3,20.0d);

            List<Product> products = new List<Product>
            {
                product,
                product1,
                product2,
                product3
            };

            Order order = new Order(products);

            order.MakeOrder();
        }
    }
}
