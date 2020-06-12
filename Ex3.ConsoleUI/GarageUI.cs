using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;

namespace Ex3.ConsoleUI
{
    class GarageUI
    {
        // this class should activate all the functions on the vehicle
        private eFunctions function;
        private List<string> currentVehicleData;
        Garage garage = new Garage();

        public GarageUI(List<string> i_CurrentVehicle)
        {
            currentVehicleData = i_CurrentVehicle;// gets a new of vehicles
        }

        public void GarageFunctions() 
        {
            Console.WriteLine("Welcome, please choose you option from the list below:");
            Console.WriteLine("1 - to enter your car to the garage \n" +
                "2 - List the vehicles in the garage \n" +
                "3 - Change vehicle status, enter license number followed by the new status [Repairing, Fixed, Paid] \n" +
                "4 - Inflate wheels to max \n" +
                "5 - Refuel gas vehicle \n" +
                "6 - Recharge electric vehicle \n" +
                "7 - To get full info about your vehicle");
            string inputOption = Console.ReadLine();
            int option;
            if(int.TryParse(inputOption,out option))
            {
                switch (option)
                {
                    case 1:
                        AddVehicle();
                        break;
                    case 2:
                        ShowVehicles();
                        break;
                    case 3:
                        ChangeStatus();
                        break;
                    case 4:
                        InflateWheelsToMax();
                        break;
                    case 5:
                        Refuel();
                        break;
                    case 6:
                        Recharge();
                        break;
                    case 7:
                        ShowInfo();
                        break;
                    default:
                        // Enter good value
                        break;
                }
            }
            else
            {

            }
        }

        //TODO - add a new vehicle with all the new information from the userscreen
        //     - do the functions the user wants acording to his choise.

        public enum eFunctions
        {
            changeVehicleStatus = 1,
            InflateTires = 2,
            Refuel = 3,
            Recharged = 4,
            //FullData = 5
        }
        public Vehicle CreateVehicle()
        {

        }

        private  void AddVehicle()
        {
            Console.WriteLine("Enter license number");
            string licenseNumber = Console.ReadLine();
            GarageCustomer currentCustomer = garage.FindCarInGarage(licenseNumber);
            if ( currentCustomer == null)
            {
                // Change cars status   
            }
            else
            {
                garage.ChangeStatus(licenseNumber, "Repairing");
            }
        }
        private void ShowVehicles()
        {
            Console.WriteLine("Insert the status you want to screen by, or press enter");
            string input = Console.ReadLine();
            if (input.Equals(""))
            {
                List<string> customers = garage.LicenseList(input);
            }
        }
        private void ChangeStatus()
        {
            Console.WriteLine("Enter license number");
            string licenseNumber = Console.ReadLine();
            Console.WriteLine("Enter status");
            string status = Console.ReadLine();
            garage.ChangeStatus(licenseNumber, status);

            // handle no such car and wrong status exceptions 
        }
            
        private void InflateWheelsToMax()
        {
            Console.WriteLine("Enter license number to inflate wheels");
            string licenseNumber = Console.ReadLine();
            garage.FindCarInGarage(licenseNumber);
            // throw exception or handle it diffrenently 
        }
        public void Refuel()
        {
            Console.WriteLine("Enter license number to refuel");
            string licenseNumber = Console.ReadLine();

            Console.WriteLine("Enter fuel type");
            string fuelType = Console.ReadLine();

            Console.WriteLine("Enter amount to fill");
            float amount; 
            float.TryParse(Console.ReadLine(), out amount);

            garage.Refuel(licenseNumber, fuelType, amount);

        }
        public void Recharge()
        {
            Console.WriteLine("Enter license number to recharge");
            string licenseNumber = Console.ReadLine();

            Console.WriteLine("Enter number of minutes you want to recharge");
            int numberOfMinutes;
            int.TryParse(Console.ReadLine(), out numberOfMinutes);

            garage.Recharge(licenseNumber, (float)numberOfMinutes / 60);

        }
        public void ShowInfo()
        {
            Console.WriteLine("Enter license number to get vehicle info");
            string licenseNumber = Console.ReadLine();

            GarageCustomer customer = garage.FindCarInGarage(licenseNumber);
            // check whatever later 
            StringBuilder vehicleInfo = new StringBuilder();
            vehicleInfo.Append("License number: "+ licenseNumber+"\n");
            vehicleInfo.Append("License number: " + licenseNumber + "\n");// model name
            vehicleInfo.Append("License number: " + licenseNumber + "\n");// owner name
            vehicleInfo.Append("License number: " + licenseNumber + "\n");// status 
            vehicleInfo.Append("License number: " + licenseNumber + "\n");// wheels info
            vehicleInfo.Append("License number: " + licenseNumber + "\n"); // fuel and type of fuel
            vehicleInfo.Append("License number: " + licenseNumber + "\n"); // rest of the information for this vehicle
            // maybe add vehicle variable that holds adittional info for each type of vehicle
            
        }
        

    }
}
