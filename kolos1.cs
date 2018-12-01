using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kolokwium_1
{
    class Program
    {

        static void Main(string[] args)
        {   int iloscPomieszczen;
            do
            {
                Console.WriteLine("Podaj ilość pomieszczeni zakres 1-10 :");
            iloscPomieszczen = wprowadzaniePom();
            } while (iloscPomieszczen == 0);
            int[,] wymiary = new int[iloscPomieszczen,2];
            for (int i = 0; i < iloscPomieszczen; i++)
            {

                Console.WriteLine($"Pomieszczenie nr {i+1}");
                do
                {
                    Console.WriteLine("Podaj szerokość pokoju w przedziale 3-40: ");
                   wymiary[i,0] = wprowadzanieSzer();
                } while (wymiary[i,0] == 0);
                do
                {
                    Console.WriteLine("Podaj długość pokoju w przedziale 2-25: ");
                    wymiary[i,1] = wprowadzanieDługo();
                } while (wymiary[i,1] == 0);

                
              
            }

            for (int j = 0; j < iloscPomieszczen; j++)
            {
                Console.WriteLine($"Plan pomieszczenia nr {j+1}");
                RysujPomieszczenie(wymiary[j,0],wymiary[j,1]);
                Console.WriteLine($"Szerokosc = {wymiary[j,0]} Dlugosc = {wymiary[j,1]} Powierzchnia = {wymiary[j, 0]* wymiary[j, 1]} m2");
            }
        }

        static int wprowadzaniePom()
        {
            int ilosc;
            if (!int.TryParse(Console.ReadLine(), out ilosc) || ilosc < 1 || ilosc > 10)
            {
                Console.WriteLine("Błędna warstość ."); return 0;
            }
            else
            {
                return ilosc;
            }


        }

         static int wprowadzanieSzer()
        {
            int szerokość;
            if (!int.TryParse(Console.ReadLine(),out szerokość)||szerokość<3||szerokość>40)
            {
                Console.WriteLine("Błędna warstość ."); return 0;
            }
            else
            {
                return szerokość;
            }
        }
        static int wprowadzanieDługo()
        {
            int x;
            if (!int.TryParse(Console.ReadLine(), out x) || x < 2 || x > 25) { Console.WriteLine("Błędna warstość ."); return 0; }
            else
            {
                return x;
            }
            
        }

        static void RysujPomieszczenie(int Szerokosc, int Dlugosc)

        {
            
            Console.Write("*");
            for (int i = 0; i < Szerokosc; i++)
            {
                Console.Write("_");
            }
            Console.WriteLine("*");
            for (int i = 0; i < Dlugosc; i++)
            {
                Console.Write("|");
                for (int ij = 0; ij < Szerokosc; ij++)
                {
                    Console.Write(".");
                }
                Console.WriteLine("|");
            }
            Console.Write("*");
            for (int i = 0; i < Szerokosc; i++)
            {
                Console.Write("_");
            }
            Console.WriteLine("*");
            

        }

    }
}
