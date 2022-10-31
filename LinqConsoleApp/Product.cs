using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqConsoleApp
{
    internal class Product
    {
        /// <summary>
        /// Название продукта
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Калорийность продукта
        /// </summary>
        public int Energy { get; set; }
        public override string ToString()
        {
            return $"{Name} ({Energy})";
        }
    }
}
