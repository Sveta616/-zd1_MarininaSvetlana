using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Zadanie1
{
  
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Введите кол-во котов");
                int count = int.Parse(Console.ReadLine());
                for(int i=0;i<count;i++)
                {
                    Console.WriteLine($"Введите имя {i + 1} кота");
                    string CatName = Console.ReadLine();
                    Console.WriteLine($"Введите вес {i + 1} кота");
                    double CatVes = Convert.ToDouble(Console.ReadLine());
                    Cat cat = new Cat(CatName, CatVes);
                    cat.Meow();
                    Console.ReadLine();
                }
            }
            catch
            {
                Console.WriteLine("Введите данные корректно");
                Console.ReadKey();
            }
        }
    } 
  
}
