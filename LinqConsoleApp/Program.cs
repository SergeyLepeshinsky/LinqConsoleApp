using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqConsoleApp
{
    internal class Program
    {
        static Random rnd = new Random();
        static void Main(string[] args)
        {
            var collection = new List<Product>();
            for (int i = 0; i < 10; i++)
            {
                var product = new Product()
                {
                    Name = "Продукт " + i,
                    Energy = rnd.Next(3, 4)
                };
                collection.Add(product);    
            }

            var res = (from i in collection
                      where i.Energy < 200
                      orderby i.Energy descending   // ого!
                      select i).ToList();
            foreach (var i in res)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();

            var res2 = collection.Where(i => i.Energy < 200).OrderByDescending(i => i.Energy).ThenBy(i => i.Name);

            foreach (var i in res2)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine();
            var m = collection.Max(i => i.Energy);  
            Console.WriteLine(m);
            Console.WriteLine();

            var groupbyCollection = collection.OrderBy(i=>i.Energy).GroupBy(i => i.Energy);  //сортировка + группировка    
            foreach (var i in groupbyCollection)
            {
                Console.WriteLine($"Ключ: {i.Key}");
                foreach (var ii in i)
                {
                    Console.WriteLine($"\t{ii}");
                }
            }
            collection.Reverse(5, 4);       // реверс коллекции c 5-го элемента 4 элемента
            foreach (var i in collection)
            {
                Console.WriteLine(i);
            }
            collection.Reverse(5, 4);

            bool all = collection.All(i => i.Energy == 5);
            Console.WriteLine(all); 
            bool any = collection.Any(i => i.Energy == 5); 
            Console.WriteLine(any);
            var prod = new Product() { Name = "Продукт 1", Energy = 3 }; 
            Console.WriteLine(collection.Contains(prod));               //???

            var arr = new int[] { 1, 2, 3, 4 };
            var arrr = new int[] { 1, 2, 7, 8 };

            Console.Write("aggregate: " + arr.Aggregate((x, y) => x * y));

            var union = arr.Union(arrr);
            foreach (var i in union)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine("Intersect");
            var intersect = arr.Intersect(arrr);
            foreach (var i in intersect)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            List<Product> products = new List<Product>() { new Product() { Name = "Новый продукт 1", Energy = 1000},
                                                           new Product(){ Name = "Новый продукт 2", Energy = 1000},
                                                           new Product(){ Name = "Продукт 3", Energy = 3 } };
            var sum = products.Sum(i => i.Energy);  // cool!
            var sumskiptake = products.Skip(1).Take(1).Sum(i => i.Energy);
            Console.WriteLine($"sumskip: {sumskiptake}");
            
            Console.WriteLine($"sum = {sum}");

            Console.Write($"single:");

            var single = products.Single(i => i.Energy == 3);

            Console.WriteLine(single);

            Console.WriteLine($"ElementAt 3: {products.ElementAt(2)}");

            var newcollection = collection.Union(products);
            foreach (var item in newcollection)
            {
                Console.WriteLine(item);
            }
            var intersectcollection = collection.Intersect(products);
            Console.WriteLine("Intersect collection:");
            foreach (var item in intersectcollection)
            {
                Console.WriteLine(item);
            }
            var grcollection = newcollection.OrderBy(i => i.Energy).GroupBy(i => i.Energy);
            foreach (var i in grcollection)
            {
                Console.WriteLine($"Ключ: {i.Key}");
                foreach (var ii in i)
                {
                    Console.WriteLine($"\t{ii}");
                }
            }

            //var resEnergy = from i in collection
            //                where i.Energy >= 200
            //                orderby i.Energy ascending
            //                select i.Name;


            //foreach (var i in resEnergy)
            //{
            //    Console.WriteLine(i);
            //}







            //var col = new List<int>();
            //for (int i = 0; i <= 10; i++)
            //{
            //    col.Add(i);
            //}
            //Console.WriteLine(col.Count);

            //var result = from i in col
            //             where i < 7 && i > 3
            //             select i;     // выбрать i удовлетворяющий условию < 5
            //foreach (var i in result)
            //{
            //    Console.Write(i + " ");
            //}
            //Console.WriteLine();
            //var result2 = col.Where(i => i > 5 && i < 9);
            //foreach (var i in result2)
            //{
            //    Console.Write(i + " ");
            //}
            //var s = col.Where(i => i > 5 && i < 9).Sum();
            //Console.WriteLine(s);
            //var result3 = col.Where(i => i > 5 && i < 9).OrderByDescending(i => i); //упорядочить в обратку
            //foreach (var i in result3)
            //{
            //    Console.Write(i + " ");
            //}
            //Console.WriteLine();
            //var result4 = col.Where(i => i > 5 && i < 9).OrderBy(i => i);    //упорядочить
            //foreach (var i in result4)
            //{
            //    Console.Write(i + " ");
            //}
            //Console.WriteLine();
            //var result5 = from i in result3
            //              orderby i descending
            //              select i;
            //foreach (var it in result5)
            //{
            //    Console.Write(it + " ");
            //}



            Console.ReadLine(); // пауза
        }
    }
}
