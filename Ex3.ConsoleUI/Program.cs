using Ex03.GarageLogic;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex3.ConsoleUI
{
    class Program
    {

        public static void Main()
        {
            eStatus status;
            eGasType vehicle;
            Console.WriteLine("Please enter status cunt : ");
            string input = Console.ReadLine();
            GarageUI ui = new GarageUI();
            while (!Enum.TryParse(input, out vehicle))
            {
                string enumOptions = "";
                
                Console.WriteLine("Wrong status value please choose from the options: " + ui.listEnumOptions(vehicle));
                input = Console.ReadLine();
            }

        }
    }
}
