using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadania
{
    class Program
    {


        static void Main(string[] args)
        {
            Console.Write("wybierz zadanie 1-4 : ");
            int x;
            int.TryParse(Console.ReadLine(), out x);
            switch (x)
            {
                case 1:
                    { zadanie1(); }
                    break;
                case 2:
                    { zadanie2(); }
                    break;
                case 3:
                    { zadanie3(); }
                    break;
                case 4:
                    { zadanie4(); }
                    break;
                default:
                    Console.WriteLine("Nie ma takiego działania.");
                    break;
            }

            //-------------------------------------------------


        }


        static void zadanie1()
        {

            Console.Write("Wpisz teks który chcesz obrócić : ");
            string input = Console.ReadLine();
            string output = createTextMirror(input);
            Console.WriteLine(input + " <--> " + output);
        }

        static void zadanie2()
        {
            Console.Write("Podaj wielkość tablicy : ");
            int[] input = new int[int.Parse(Console.ReadLine())];
            int[] output = new int[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                Console.Write("Podaj {0} liczbę z tablicy : ", i + 1);
                input[i] = int.Parse(Console.ReadLine());
            }
            output = magicNumbers(input);
            foreach (var item in output)
            {
                Console.Write(" {0} ", item);
            }
        }


        static void zadanie3()
        {
            Console.Write("Który wyraz ciągu fibo mam wyświetlić : ");
            int nElement = int.Parse(Console.ReadLine());

            Console.WriteLine("{0} elementem jest {1} ", nElement, fibonacci(nElement));

        }

        static void zadanie4()
        {
            Console.WriteLine("Wprowadź tekst który mam sprawdzić : ");

            if (isPalindrome(Console.ReadLine()))
            { Console.WriteLine("Jest palindromem."); }
            else
            { Console.WriteLine("Nie jest palindromem."); }
        }




        //---------------------------------------------------



        static string createTextMirror(string inputText)
        {
            string outputText = "";
            for (int i = inputText.Length - 1; i >= 0; i--)
            {
                if (i % 2 != 0)
                {
                    string a = Convert.ToString(inputText[i]);
                    outputText += a.ToUpper();
                }
                else
                {
                    outputText += inputText[i];
                }

            }

            return outputText;
        }

        static int[] magicNumbers(int[] input)
        {
            if (input.Length < 2)
                return input;

            int[] result = new int[(input.Length / 2) + (input.Length % 2)]; //inicjowanie nowej tablicy

            int result_idx = 0; //indeks w tablicy wynikowej
            int input_idx = 0; //indeks w tablicy wejsciowej



            for (; input_idx < input.Length - 1; input_idx += 2)
            {
                if (input[input_idx] == 0)
                { result[result_idx] = input[input_idx + 1]; continue; }
                else if (input[input_idx + 1] == 0)
                { result[result_idx] = input[input_idx]; continue; }
                else
                {
                    int smaller;
                    if (input[input_idx] > input[input_idx + 1])
                    { smaller = input[input_idx + 1]; }
                    else
                    { smaller = input[input_idx]; }



                    result[result_idx] = ((input[input_idx] + input[input_idx + 1]) / smaller);
                    result_idx++;
                }
            }

            if (input.Length % 2 != 0)
                result[result_idx] = input[input.Length - 1];

            return result;
        }

        static int fibonacci(int nElement)
        {
            int[] tab = new int[3];
            tab[0] = 0;
            tab[1] = 1;
            for (int i = 0; i < nElement - 1; i++)
            {
                tab[2] = tab[1] + tab[0];
                tab[0] = tab[1];
                tab[1] = tab[2];

            }

            return tab[2];
        }

        static bool isPalindrome(string inputText)
        {

            int leng = inputText.Length-1;
            
            for (int i = 0; i < inputText.Length/2+inputText.Length%2; i++)
            {
                
                if (inputText[i] != inputText[leng])//revers[leng])
                { return false; }
                leng--;
            }


            return true;
        }

    }


}
