using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex3.ConsoleUI
{
    class UserScreenSheet
    {
        // thoose messages will see the user every time a new coustomer comes
        public static void main()
        {
            Console.WriteLine("Wellcome to garage");
            Console.WriteLine("First lets register your vehicle, please enter your name");
            string inputName = Console.ReadLine();
            // CLEAR SCREEN ................
            Ex3.ConsoleUI.ConsoleUtils.Screen.Clear();
            Console.WriteLine("Enter your phone number , in this pattern : 050 - 1234567");
            string inputPhoneNumber = Console.ReadLine();
            // CLEAR SCREEN ................
            Ex3.ConsoleUI.ConsoleUtils.Screen.Clear();
            Console.WriteLine("Enter your license plate:");
            string inputLicensePlate = Console.ReadLine();
            // CLEAR SCREEN ................
            Ex3.ConsoleUI.ConsoleUtils.Screen.Clear();
            Console.WriteLine("Enter your vehicle's model name:");
            string inputModedlName = Console.ReadLine();
            // CLEAR SCREEN ................
            Ex3.ConsoleUI.ConsoleUtils.Screen.Clear();
            Console.WriteLine("Enter the Car's remainig energy:");
            string inputRemainnigEnergy = Console.ReadLine();
            // CLEAR SCREEN ................
            Ex3.ConsoleUI.ConsoleUtils.Screen.Clear();
            Console.WriteLine("Please choose your vehicle type and write it: Car(on fuel), Electric Car, Motorcycle(on fuel), Electric Motorcycle, Truck(on fuel)");
            string inputVehicleType = Console.ReadLine();
            // CLEAR SCREEN ................
            Ex3.ConsoleUI.ConsoleUtils.Screen.Clear();


            //if he choocecs Car
            if (inputVehicleType.Equals("Car"))
            {
                Console.WriteLine("Enter your Car's color:");
                string inputCarColor = Console.ReadLine();
                Console.WriteLine("Enter the amount of doors your car's have:");
                string inputDoorsAmount = Console.ReadLine();
                Console.WriteLine("Enter your Car's fuel type: Soler, Octan95, Octan96, Octan98");
                string inputFuelType = Console.ReadLine();
                // CLEAR SCREEN ................
                Ex3.ConsoleUI.ConsoleUtils.Screen.Clear();
            }
            //if he choocecs electric Car
            if (inputVehicleType.Equals("Electric Car"))
            {
                Console.WriteLine("Enter your Car's color:");
                string inputCarColor = Console.ReadLine();
                Console.WriteLine("Enter the amount of doors your car's have:");
                string inputDoorsAmount = Console.ReadLine();
                // CLEAR SCREEN ................
                Ex3.ConsoleUI.ConsoleUtils.Screen.Clear();
            }
            //if he choocecs Motorcycle
            if (inputVehicleType.Equals("Motorcycle"))
            {
                Console.WriteLine("Enter your license drive type: A, A1, AA, B");
                string inputlicenseType = Console.ReadLine();
                Console.WriteLine("Enter engine volume:");
                string inputengineVolume = Console.ReadLine();
                // CLEAR SCREEN ................
                Ex3.ConsoleUI.ConsoleUtils.Screen.Clear();
            }
            //if he choocecs Electric Motorcycle
            if (inputVehicleType.Equals("Electric Motorcycle"))
            {
                Console.WriteLine("Enter your license drive type: A, A1, AA, B");
                string inputlicenseType = Console.ReadLine();
                Console.WriteLine("Enter engine volume:");
                string inputengineVolume = Console.ReadLine();
                // CLEAR SCREEN ................
                Ex3.ConsoleUI.ConsoleUtils.Screen.Clear();
            }
            if (inputVehicleType.Equals("Truck"))
            {
                Console.WriteLine("The truck has dangerousSubstances?: Yes or No");
                string inputdangerousSubstances = Console.ReadLine();
                Console.WriteLine("Enter the Truck's trunk capacity:");
                string inputtrunkCapacity = Console.ReadLine();
                // CLEAR SCREEN ................
                Ex3.ConsoleUI.ConsoleUtils.Screen.Clear();
            }
                
            //TODO - add the new vehicle to the garage, and afater ask more questions

            Console.WriteLine("What would you like to do , enter the number of your choise:/n", "1 - Add new vehicle/n", "2 - See the list of the vehiclels in the garage?/n", "3 - Take car on your vehicle");
            string inputChoise = Console.ReadLine();
            if (inputChoise.Equals("3"))
            {
                // Go TO the garage
            }
            else if (inputChoise.Equals("1"))
            {
                //Start all over
            }
            else
            {
                // TODO - print the list of vehicles in the garage with an option not to see everyone
            }
        }
        public static string ValidInput(string i_StringInput)
        {

        }
    }
}
