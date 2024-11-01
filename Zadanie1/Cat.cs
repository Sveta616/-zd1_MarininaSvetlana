using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1
{

    class Cat
    {
        private string name;
        private double ves;
        //проверка веса на цифры и значения(не равно 0 и не меньше)
        public double Ves
        {
            get
            {
                return ves;
            }
            set
            {
                bool onlyCounts = true;
            
                string valuestr = value.ToString();

                foreach (var ch in valuestr)
                {
                    if (!char.IsDigit(ch) && ch != '.') 
                    {
                        onlyCounts = false;
                        break; 
                    }
                }

                if (onlyCounts)
                {
                    ves = double.Parse(valuestr); 
                }
                else
                {
                    Console.WriteLine($"{valuestr} - нельзя буквы!!!");
                }

                if (value <= 0)
                {
                    Console.WriteLine("Вес не может быть нулевым или отрицательным!");
                }
                else
                {
                    ves = value;
                }
            }
        }
        //проверка имени на буквы
        public string Name
        {
        
            get
            {
                return name;
            }
        
            set
            {
                bool OnlyLetters = true;
              
                foreach (var ch in value)
                {
                    if (!char.IsLetter(ch))
                    {
                        OnlyLetters = false;
                    }
                }

                if (OnlyLetters)
                {
                    name = value;
                }
                else
                {
                    Console.WriteLine($"{value} - неправильное имя!!!");
                }
            }
        }
        //констуктор
        public Cat(string CatName, double CatVes)
        {
            Name = CatName;
            Ves = CatVes;
        }
        // метод для опознания отдельно взятого кота
        public void Meow()
        {
            Console.WriteLine($"{name}: МЯЯЯЯУ!!!!");
            Console.WriteLine($"{ves} кг");
        }
    
      
    }
}
