using System;

namespace ConsoleApp1
{
    class Program
	{
		static void Main(string[] args)
		{/*
            Console.WriteLine("Podaj wysokość choinki : ");
           if( !int.TryParse(Console.ReadLine(),out int hight))// sprawdzenie czy uda się próba przekonwertowania wejściowego ciągu znaków na typ int
            { Console.WriteLine("błędna wartość");return; }// jeśli się nie uda wypisanie komunikatu i zakończenie programu
            int stars = 1;// deklaracja i przypisanie wartości do zmiennej przechowującej ilość gwiazdek w lini
            for (int i = 1; i <= hight+2; i++)// mainloop odpowiedzialna za wysokość choinki
            {int emptyChar = hight-i; // ustalanie ilosci spacji w danej iteracji
                int stars2 = stars;  // stars2 zmienna do zerowania 
                for (int l = (hight*2)-1; l>0 ; l--) // pętla odpowiedzialna za wypisywanie lini
                {
                   if (i > hight && l==hight) { Console.Write("|"); }  // wypisywanie pnia choinki 
                   // i>wysokości choinki i ustawienie w środku l == height
                   else if (emptyChar <= 0  &&  stars2!=0  &&  i<=hight) { Console.Write("*");stars2--; }
                   // wypisywanie gwiazdek
                   else { Console.Write(" "); }  // wypisywanie spacji  
                   // wypisywani spacji 
                    emptyChar--;// zmniejszanie ilości spacji co iterację 
                }
                stars +=2; // zwiększenie ilości gwiazdek w lini o dwie 
                Console.WriteLine(); // nowa linia

            }
            */


            Choinka choinka = new Choinka();

            Console.WriteLine("Podaj wysokość choinki : ");
            if (!int.TryParse(Console.ReadLine(), out int hight))
            { Console.WriteLine("błędna wartość"); return; }

            Choinka.getValue(hight);
            choinka.Printing();

        }
       
        
    }

    class Choinka
    {
        private static int hight;
        public static void getValue(int x)
        {
            hight = x;
        }

        private  void printTrunk()
        { Console.Write("|"); }
        private void printStar()
        { Console.Write("*"); }
        private void printSpace()
        { Console.Write(" "); }


        public void Printing()
        {
            int stars = 1;
            for (int i = 1; i <= hight + 2; i++)
            {
                int emptyChar = hight - i;
                int stars2 = stars;
                for (int l = (hight * 2) - 1; l > 0; l--) 
                {   
                    if (emptyChar <= 0 && stars2 != 0 && i <= hight) { printStar(); stars2--; }

                    else if (i > hight && l == hight) { printTrunk(); }   

                    else { printSpace(); }  

                    emptyChar--;
                }

                stars += 2; 

                Console.WriteLine(); 

            }



        }


    }
}

