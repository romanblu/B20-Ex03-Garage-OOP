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

             Console.WriteLine("Wellcome what would you like to do , write the digit of your choise: \n 1 - Add new vehicle \n 2 - See the list of the vehiclels in the garage\n 3 - Take care of your vehicle");
             string inputChoise = Console.ReadLine();
             if (inputChoise.Equals("3"))
             {
                     // Go TO the GarageUi
             }
             else if (inputChoise.Equals("1"))
             {
                GarageAddVehicleUI.WellcomeToGarage();
                //Add a new vehicle
             }
             else
             {
                List<string> status = new List<string>();
                Console.WriteLine("If you dont want to see all the vehicles in the garge, you can choose the status of vehicles you would like not to see: Repairing, Fixed,Paid . or press enter");
                string inputStatus = Console.ReadLine();
                    // TODO - print the list of vehicles in the garage with an option not to see everyone
            }
                //TODO
        } 
    }
}
