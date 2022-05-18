using System;
using System.Collections.Generic;
using System.Text;

namespace P324_Reflection_Exception
{
    class Order
    {
        public List<Product> Products;
        public double TotalPrice;
        public DateTime Date;

        public Order(List<Product> products)
        {
            Products = products;
            Date = DateTime.Now;
            TotalPrice = 0d;
        }

        public void MakeOrder(Func<double> func = null)
        {
            Products.ForEach(p =>
            {
                TotalPrice += p.Price * p.Count;
            });

            func ??= MakeDiscount;

            Console.WriteLine(Date);
            Console.WriteLine($"Total price: {Math.Round(TotalPrice * func(),2)}");
        }

        public double MakeDiscount()
        {
            if(TotalPrice > 100 && TotalPrice < 200)
            {
                Console.WriteLine($"10% endrim tetbiq olundu. Endrimsiz qiymet: {TotalPrice}");
                return 0.9d;
            }else if (TotalPrice >= 200)
            {
                Console.WriteLine($"20% endrim tetbiq olundu. Endrimsiz qiymet: {TotalPrice}");
                return 0.8d;
            }
            else
            {
                return 1;
            }
        }
    }
}
