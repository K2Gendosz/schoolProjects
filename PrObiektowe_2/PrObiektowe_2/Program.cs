using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrObiektowe_2
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Podaj marke : ");
            string Mark = Console.ReadLine();
            Console.WriteLine("Podaj model : ");
            string Model = Console.ReadLine();
            Console.WriteLine("Podaj poj silnika : ");
            string silnik = Console.ReadLine();
            Console.WriteLine("Podaj poj baku  : ");
            string bak = Console.ReadLine();
            Console.WriteLine("Podaj ilosc paliwa : ");
            string paliwo = Console.ReadLine();

            Car c = new Car(Mark,Model,silnik,bak,paliwo);

            c.Drive(60);


        }
    }
}
