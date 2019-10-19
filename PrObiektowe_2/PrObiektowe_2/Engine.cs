using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrObiektowe_2
{
    class Engine
    {
        readonly double enginCapacity;
        readonly double tankCapacity;
        private double tankFill;
        double km;

       


        public Engine(string EngineCapacity,string TankFill)
        {
            this.tankCapacity = 40;

            if ((!double.TryParse(EngineCapacity,out this.enginCapacity))||enginCapacity<0)
            {
                Console.WriteLine("Wrong value");
            }
            if ((!double.TryParse(TankFill, out this.tankFill)) || this.tankFill < 0 || this.tankFill>this.tankCapacity)
            {
                Console.WriteLine("Wrong value");
            }
            
        }

        public Engine( string EngineCapacity,string TankCapacity, string TankFill) : this(EngineCapacity, TankFill)
        {
            
            if ((!double.TryParse(TankCapacity, out this.tankCapacity)) || this.tankCapacity < 0)
            {
                Console.WriteLine("Wrong value");
            }
            
        }

        public double Combustion(double KmToDrive)
        {
            double combution = this.enginCapacity * 4;
            
            if (tankFill>= (combution * KmToDrive) / 100)
            {
                tankFill -= combution * KmToDrive / 100;
                return KmToDrive;
            }
            else
            {
                km = (tankFill * 100) / combution;
                tankFill = 0;
                return km;
            }

        }






        
        public static double LitrToGal(double engineCapacity)
        {

            return 235.2/(engineCapacity*4);
        }
        public static double GalToLitr(double Mpg)
        {

            return 235.2/Mpg;
        }
        




    }
}
