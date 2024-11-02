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


        public Shop()
        {
            products = new Dictionary<Product, int>();
        }

        public void AddProduct(Product product, int count)
        {
            products.Add(product, count);
        }

        public void CreateProduct(string name,double price, int count)
        {
            if (FindByName(name) != null)
            {
                MessageBox.Show($"Продукт '{name}' уже существует!");
                return;
            }
            products.Add(new Product(name, price), count);
        }

        public void WriteAllProducts()
        {
            MessageBox.Show("Список продуктов: ");
            foreach (var product in products)
            {
                MessageBox.Show(product.Key.GetInfo() + "; Количество: " + product.Value);
            }
        }
        public List<Product> GetAllProducts()
        {

            List<Product> productList = new List<Product>();


            foreach (var product in products)
            {
                productList.Add(product.Key);
            }


            return productList;
        }
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

        public void Sell(string productName)
        {
            Product toSell = FindByName(productName); 
         
            if (toSell != null)
            {
                if (products[toSell] > 0)
                {
                    products[toSell]--;
                  
                    MessageBox.Show($"Продано: {toSell.Name}. Осталось: {products[toSell]}");
                   
                }
                else
                {
                    MessageBox.Show("Товар закончился!");
                }
            }
            else
            {
                MessageBox.Show("Товар не найден!");
            }

        }
        public int GetQuantity(Product product)
        {
            if (products.ContainsKey(product))
            {
                return products[product];
            }
            return 0; 
        }
    }

}


