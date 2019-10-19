using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace PrObiektowe_2
{
    class Car
    {
        private string mark;
        private string model;
        private Engine engine;


        public Car(string Mark,string Model,string EngineCapacity, string TankCapacity, string TankFill)
        {
            this.mark = Mark;
            this.model = Model;
            engine = new Engine(EngineCapacity, TankCapacity, TankFill);

        }

        public void Drive(double KmToDrive)
        {
            engine.Combustion(KmToDrive);
            Thread.Sleep(int.Parse(KmToDrive.ToString())*100);
            if (engine.Combustion(KmToDrive)==KmToDrive)
            {
                Console.WriteLine("Jestem");
            }
            else
            {
                Console.WriteLine($"Przejechałem {engine.Combustion(KmToDrive)} km");
            }
        }


    }
}
