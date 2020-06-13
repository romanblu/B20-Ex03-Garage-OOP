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
        CreateNewVehicle factory = new CreateNewVehicle();
        List<Vehicle> userVehicles = new List<Vehicle>();

        public GarageUI(List<string> i_CurrentVehicle)
        {
            currentVehicleData = i_CurrentVehicle;// gets a new of vehicles
        }

        public void GarageFunctions()
        {
            Console.WriteLine("Welcome, please choose you option from the list below:");
            Console.WriteLine("0 - Create you vehicle \n" +
                "1 - to enter your car to the garage \n" +
                "2 - List the vehicles in the garage \n" +
                "3 - Change vehicle status, enter license number followed by the new status [Repairing, Fixed, Paid] \n" +
                "4 - Inflate wheels to max \n" +
                "5 - Refuel gas vehicle \n" +
                "6 - Recharge electric vehicle \n" +
                "7 - To get full info about your vehicle");
            string inputOption = Console.ReadLine();
            int option;
            if (int.TryParse(inputOption, out option))
            {
                switch (option)
                {
                    case 0:
                        CreateVehicle();
                        break;
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


        public void CreateVehicle()
        {
            Vehicle currentVehicle;
            Console.WriteLine("Enter model name");
            string modelName = Console.ReadLine();
            Console.WriteLine("Enter license number");
            string licenseNumber = Console.ReadLine();
            Console.WriteLine("Enter energy left");
            string input = Console.ReadLine();
            float energyLeft;
            float.TryParse(input, out energyLeft); // maybe change it to string and send to Logic to handle types, throw format exception
            Console.WriteLine("Enter vehicle type");
            string vehicleType = Console.ReadLine();
            
            factory.VehicleInProduction(vehicleType, modelName, licenseNumber, energyLeft); // check if info is good 

            List<string> extraData = factory.GetExtraData(vehicleType);
            Console.WriteLine("Enter additional information about your " + vehicleType);
            for(int i=0;i<extraData.Count;i++)
            {
                Console.WriteLine("Enter "+ extraData[i].ToLower());
                extraData[i] = Console.ReadLine();
            }
            currentVehicle = factory.FinishProduction(extraData);

            Console.WriteLine("All wheels inflated to the max, enter \"yes\" if you want to change the pressure or enter to leave it at max");
            input = Console.ReadLine();
            if(input == "yes")
            {
                Console.WriteLine("Enter air pressure for all wheels or ENTER if you want to change individually");
                input = Console.ReadLine();
                if (input == "")
                {
                    // change individually 
                }
                else
                {
                    // make garage func for changing wheel pressure
                }
                
            }

            userVehicles.Add(currentVehicle);
        }
        private Vehicle GetUserVehicle(string i_LicenseNumber)
        {
            foreach(Vehicle vehicle in userVehicles)
            {
                if(vehicle.LicenseNumber == i_LicenseNumber)
                {
                    return vehicle;
                }
            }
            return null;
        }

        private  void AddVehicle()
        {

            Vehicle currentVehicle;
      
            Console.WriteLine("Enter license number");
            string licenseNumber = Console.ReadLine();

            currentVehicle = GetUserVehicle(licenseNumber);

            if (currentVehicle == null)
            {
                Console.WriteLine("You didnt create such vehicle, press 0 and create it");
                GarageFunctions();

            }
            else
            {
                Console.WriteLine("Enter owner name");
                string ownerName = Console.ReadLine();
                Console.WriteLine("Enter phone number");
                string phoneNumber = Console.ReadLine();
                if (garage.InsertVehicle(currentVehicle, ownerName, phoneNumber))
                {
                    Console.WriteLine("Vehicle was inserted successfuly");
                    // open options menu
                    GarageFunctions();
                }
                else
                {
                    Console.WriteLine("Vehicle already in the garage, updated status to Repairing");
                    // open options menu
                    GarageFunctions();
                }
            }
        }
        private void ShowVehicles()
        {
            Console.WriteLine("Insert the status you want to screen by, or press enter");
            eStatus status;
            string input = Console.ReadLine();
            
            List<string> customers;
            if (input.Equals(""))
            {
                customers = garage.LicenseList();
            }
            else
            {
                Enum.TryParse(input, out status);
                customers = garage.LicenseList(status);
            }
        }
        private void ChangeStatus()
        {
            Console.WriteLine("Enter license number");
            string licenseNumber = Console.ReadLine();
            Console.WriteLine("Enter status");
            string input = Console.ReadLine();
            eStatus status;
            Enum.TryParse(input, out status);
            garage.ChangeStatus(licenseNumber, status);

        }
            
        private void InflateWheelsToMax()
        {
            Console.WriteLine("Enter license number to inflate wheels");
            string licenseNumber = Console.ReadLine();
            garage.FindVehicleInGarage(licenseNumber);
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

            GarageCustomer customer = garage.FindVehicleInGarage(licenseNumber);
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
    public enum eFunctions
    {
        changeVehicleStatus = 1,
        InflateTires = 2,
        Refuel = 3,
        Recharged = 4,
        //FullData = 5
    }
}
