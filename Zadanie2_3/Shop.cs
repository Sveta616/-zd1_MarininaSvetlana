using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zadanie2
{
    class Shop
    {


        private Dictionary<Product, int> products;
        private double sum;


        public Shop()
        {
            products = new Dictionary<Product, int>();
            sum = 0;
        }

      
        //создание продукта и проверка на сущесвующий
        public void CreateProduct(string name, double price, int count)
        {
            if (FindByName(name) != null)
            {
                MessageBox.Show($"Продукт '{name}' уже существует!");
                return;
            }
            products.Add(new Product(name, price), count);
        }
        //вывод списка при помощи сообщения
        public void WriteAllProducts()
        {
            MessageBox.Show("Список продуктов: ");
            foreach (var product in products)
            {
                MessageBox.Show(product.Key.GetInfo() + "; Количество: " + product.Value);
            }
        }
        //добавление в лист, получение
        public List<Product> GetAllProducts()
        {

            List<Product> productList = new List<Product>();


            foreach (var product in products)
            {
                productList.Add(product.Key);
            }


            return productList;
        }
        //нахождение такого же имени(существующего)
        public Product FindByName(string name)
        {
            foreach (var product in products.Keys)
            {
                if (product.Name == name)
                {
                    return product;
                }
            }
            return null;
        }
        //проверка на наличие товара при покупке, вывод общей стоимости всех продуктов магазина
        public void Sell(string productName, int quantity)
        {
            Product toSell = FindByName(productName);

            if (toSell != null)
            {
               
                if (products[toSell] <= 0)
                {
                    MessageBox.Show("Товар закончился!");
                }
                else if (products[toSell] < quantity) 
                {
                    MessageBox.Show("Недостаточно товара на складе!"); 
                }
                else
                {
                    products[toSell] -= quantity;
                    sum += toSell.Price * quantity; 
                    MessageBox.Show($"Продано: {toSell.Name}. Осталось: {products[toSell]}");
                    MessageBox.Show($"Общая прибыль магазина: {sum}");


                    if (products[toSell] <= 0)
                    {
                        MessageBox.Show("Товар закончился!"); 
                    }
                }
            }
            else
            {
                MessageBox.Show("Товар не найден!"); 
            }
        }
        //добавила свой метод удаление продукта по имени
        public void Delete(string name)
        {
            Product productDelete = FindByName(name);
            if (productDelete != null)
            {
                products.Remove(productDelete);
                MessageBox.Show($"Продукт '{name}' удален из магазина.");
            }
            else
            {
                MessageBox.Show($"Продукт '{name}' не найден.");
            }
        }
    }
}



