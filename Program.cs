using System;

namespace ConsoleApp1
{
    class Program
	{
		static void Main(string[] args)
		{
            Console.WriteLine("Podaj wysokość choinki : ");
           if( !int.TryParse(Console.ReadLine(),out int hight))
            { Console.WriteLine("błędna wartość");return; }
            int stars = 1;
            for (int i = 1; i <= hight+2; i++)
            {int emptyChar = hight-i; 
                int stars2 = stars;  
                for (int l = (hight*2)-1; l>0 ; l--) 
                {
                   if (i > hight && l==hight) { Console.Write("|"); }  
                  
                   else if (emptyChar <= 0  &&  stars2!=0  &&  i<=hight) { Console.Write("*");stars2--; }
                  
                   else { Console.Write(" "); }   
                   
                    emptyChar--; 
                }
                stars +=2; 
                Console.WriteLine(); 

            }
            


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

