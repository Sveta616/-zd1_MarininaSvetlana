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
    
        //конструктор
        public Product(string name, double price)
        {
            this.name = name;
            this.price = price;
         
        }
        //открываем поле для поиска существующего имени в Shop
        public string Name
        {
            get 
            {
                return name;
            }
        }
        //открываем поле для подсчёта общей суммы в Shop
        public double Price
        {
            get
            {
                return price;
            }
        }
        //Вывод

        public string GetInfo()
        {
            return $"Название продукта: {name}; Цена: {price}";
        }
     
       
    }


}


