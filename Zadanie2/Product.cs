using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie2
{
    class Product
    {
        private double price;
        private string name;
    

        public Product(string name, double price)
        {
            this.name = name;
            this.price = price;
         
        }

        public string Name
        {
            get 
            {
                return name;
            }
        }

        public string GetInfo()
        {
            return $"Название продукта: {name}; Цена: {price}";
        }
     
       
    }


}


