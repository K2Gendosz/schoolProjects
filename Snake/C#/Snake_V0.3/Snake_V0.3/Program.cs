using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


// width 50 height = 40


namespace Snake_V0._3
{
    class Snake
    {
        public int HeadX;
        public int HeadY;

    }
    class Program
    {
        static List<Snake> Parts = new List<Snake>();

        static bool IsEndGame;
        static bool IsEaten = true;
        static int FoodX, FoodY;
        static int HeadX, HeadY, TempX, TempY;
        static int FoodTempX, FoodTempY;
        static int Points;
        static string Direction;


        static void Main(string[] args)
        {
            ShowMenu();
        }
        static void ShowMenu()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetWindowSize(50,40);
            Console.WriteLine("##################################################");
            Console.WriteLine("#                                                #");
            Console.WriteLine("#            Snake by Kacper Gendosz             #");
            Console.WriteLine("#                                                #");
            Console.WriteLine("#                      Menu                      #");
            Console.WriteLine("#                                                #");
            Console.WriteLine("#                                                #");
            Console.WriteLine("#                  1. New Game                   #");
            Console.WriteLine("#                  0. Exit                       #");
            Console.WriteLine("#                                                #");
            Console.WriteLine("#                                                #");
            Console.WriteLine("##################################################");
            ConsoleKey choice = ConsoleKey.Enter;
            while (!IsEndGame)
            {
                if (Console.KeyAvailable)
                {
                    choice = Console.ReadKey(true).Key;
                    switch (choice)
                    {

                        case ConsoleKey.D1:
                            NewGame();
                            break;
                        case ConsoleKey.D0:
                            Console.WriteLine("Good Bye");
                            Thread.Sleep(500);
                            break;
                        default:
                            continue;
                    }
                    break;
                }
               
            }


        }
        static void PrintBorder()
        {
            Console.Clear();
            for (int i = 0; i < 50; i++)
            {
                Console.Write("#");
            }
            for (int i = 1; i < 30; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("#");
                Console.SetCursorPosition(49, i);
                Console.Write("#");
            }
            Console.WriteLine();
            for (int i = 0; i < 50; i++)
            {
                Console.Write("#");
            }
            Console.SetCursorPosition(25, 15);
        }
        static void NewGame()
        {
            Parts.Clear();
            IsEaten = true;
            IsEndGame = false;
            Points = 0;
            PrintBorder();
            Movement();
        }
        static void Movement()
        {
            ConsoleKey direction = Console.ReadKey(true).Key;
            ConsoleKey tempDir = direction;
            HeadX = Console.CursorLeft;
            HeadY = Console.CursorTop;

            Snake TempSnake = new Snake();
            TempSnake.HeadX = HeadX;
            TempSnake.HeadY = HeadY;
            Parts.Add(TempSnake);
            Parts.Add(TempSnake);

            Direction = " ";

            while (!IsEndGame)
            {
                TempX = HeadX;
                TempY = HeadY;

                Food();

                if (Colisions())
                {
                    ShowMenu();
                    return;
                }
               

                if (Console.KeyAvailable)
                {
                    direction = Console.ReadKey(true).Key;
                }
                switch (direction)
                {
                    
                    case ConsoleKey.Escape:
                        ShowMenu();
                        return;
                    case ConsoleKey.LeftArrow:
                        if (Direction!="right")
                        {
                            Direction = "left";
                            HeadX--;
                        }
                        else
                        {
                            direction = ConsoleKey.RightArrow;
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        if (Direction != "down")
                        {
                            Direction = "up";
                            HeadY--;
                        }
                        else
                        {
                            direction = ConsoleKey.DownArrow;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (Direction != "left")
                        {
                            Direction = "right";
                            HeadX++;
                        }
                        else
                        {
                            direction = ConsoleKey.LeftArrow;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (Direction != "up")
                        {
                            Direction = "down";
                            HeadY++;
                        }
                        else
                        {
                            direction = ConsoleKey.UpArrow;
                        }
                        break;
                    case ConsoleKey.P:
                        break;
                    default:
                        direction = tempDir;
                        continue;
                }
                Snake NewHead = new Snake();
                NewHead.HeadX = HeadX;
                NewHead.HeadY = HeadY;
                Parts.Add(NewHead);
                print();
                Parts.Remove(Parts[0]);
                // printing logic 
                Thread.Sleep(100);

            }
            

        }
       
        static void Food()
        {
            if (IsEaten==true)
            {
                Random Rand = new Random();
                FoodX = Rand.Next(1, 49);
                FoodY = Rand.Next(1, 30);
                FoodTempX = Console.CursorLeft;
                FoodTempY = Console.CursorTop;
                Console.SetCursorPosition(FoodX,FoodY);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("*");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(FoodTempX, FoodTempY);
                IsEaten = false;
            }


        }
        static bool Colisions()
        {
            //with food 
            if (HeadX==FoodX&&HeadY==FoodY)
            {
                Snake NewHead = new Snake();
                NewHead.HeadX = HeadX;
                NewHead.HeadY = HeadY;
                Parts.Add(NewHead);
                Points += 1;
                IsEaten = true;
                return false;
               
            }
            //with border 
            if (HeadX == 0||HeadX==49||HeadY==0||HeadY==30)
            {
                PrintEnd();
                Console.ReadKey();
                return true;
                
            }
            //with body
            for (int i = 1; i < Parts.Count-2 ; i++)
            {
                if (HeadX==Parts[i].HeadX&&HeadY==Parts[i].HeadY)
                {
                    PrintEnd();
                    Console.ReadKey();
                    return true;
                }
            }
            return false;
        }



        //------------------------
        static void print()
        {
           // Console.Write(Parts.Count);
            for (int i = Parts.Count-2;i>0; i--)
            {
                Console.SetCursorPosition(Parts[i].HeadX,Parts[i].HeadY);
                Console.Write("O");
            }
            Console.SetCursorPosition(Parts[0].HeadX, Parts[0].HeadY);
            Console.Write(" ");
           // Console.ReadKey();
        }    // to change
        //------------------------


        static void PrintEnd()
        {
            Console.SetCursorPosition(15,10);
            for (int i = 0; i < 20; i++)
            {
                Console.Write("*");
            }
            for (int i = 0; i < 10; i++)
            {
                Console.SetCursorPosition(15,10+i);
                Console.Write("*");
                Console.SetCursorPosition(34, 10 + i);
                Console.Write("*");
            }
            Console.SetCursorPosition(15, 20);
            for (int i = 0; i < 20; i++)
            {
                Console.Write("*");
            }
            Console.SetCursorPosition(16, 11);
           
            Console.SetCursorPosition(16,11);
            Console.WriteLine("      End Game");
            Console.SetCursorPosition(16, 13);
            Console.WriteLine(" Your Points : {0}",Points );

        }

    }
}
