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
        private List<string> currentVehicleData;
        Garage garage = new Garage();
        CreateNewVehicle factory = new CreateNewVehicle();
        List<Vehicle> userVehicles = new List<Vehicle>();
        Validator validator = new Validator();

        public GarageUI()
        {
            
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
                        Console.WriteLine("Please enter a number from 0 to 7");
                        GarageFunctions();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Please enter a number from 0 to 7");
                GarageFunctions();
            }
        }
        public string ListEnumOptions(Enum i_Enum)
        {
            StringBuilder enumListing = new StringBuilder();

            for (int i = 0; i < Enum.GetNames(i_Enum.GetType()).Length; i++)
            {
                enumListing.Append(Enum.GetNames(i_Enum.GetType())[i]);
                if (i != Enum.GetNames(i_Enum.GetType()).Length - 1)
                {
                    enumListing.Append(", ");
                }
            }
            return enumListing.ToString();
        }

        private Vehicle GetUserVehicle(string i_LicenseNumber)
        {
            foreach (Vehicle vehicle in userVehicles)
            {
                if (vehicle.LicenseNumber == i_LicenseNumber)
                {
                    return vehicle;
                }
            }
            return null;
        }

        // function #0
        public void CreateVehicle()
        {
            Vehicle currentVehicle;
            Console.WriteLine("Enter model name");
            string modelName = Console.ReadLine();
            Console.WriteLine("Enter license number");
            string licenseNumber = Console.ReadLine();
            Console.WriteLine("Enter energy left");
            string input = Console.ReadLine();
            float energyLeft = validator.ValidateEnergyLeft(input);

            Console.WriteLine("Enter vehicle type");
            input = Console.ReadLine(); // validate Enum type 
            eVehicleType vehicleType = validator.ValidateEnumType<eVehicleType>(input);
            
            factory.VehicleInProduction(vehicleType, modelName, licenseNumber, energyLeft);
            List<string> extraData = new List<string>();
            extraData = factory.GetExtraData(vehicleType);
            for (int i = 0; i < extraData.Count; i++)
            {
                Console.WriteLine("Enter additional information about your " + vehicleType);
                Console.WriteLine("Enter " + extraData[i].ToLower());
                extraData[i] = Console.ReadLine();
            }

            currentVehicle = validator.ValidateExtraDataForVehicleType(extraData, factory, vehicleType);
            
            Console.WriteLine("All wheels inflated to the max, enter \"yes\" if you want to change the pressure or enter to leave it at max");
            input = Console.ReadLine();
            if(input == "yes")
            {
                Console.WriteLine("Enter air pressure for all wheels or ENTER if you want to change individually");
                input = Console.ReadLine();
                if (input == "")
                {
                    for(int i = 0; i < currentVehicle.Wheels.Count; i++)
                    {
                        Console.WriteLine("Enter air pressure value for wheel #{0}", i + 1);
                        float airPressure;
                        float.TryParse(Console.ReadLine(), out airPressure);// formatexcecption
                        currentVehicle.Wheels[i].Inflate(airPressure);
                    } 
                }
                else
                {
                    Console.WriteLine("Enter air pressure value for all wheels");
                    float airPressure;
                    float.TryParse(Console.ReadLine(), out airPressure);// formatexcecption
                    for (int i = 0; i < currentVehicle.Wheels.Count; i++)
                    {
                        currentVehicle.Wheels[i].Inflate(airPressure);
                    }
                }

            }

            userVehicles.Add(currentVehicle);
        }

        // function #1
        private  void AddVehicle()
        {

            Vehicle currentVehicle;
      
            Console.WriteLine("Enter license number");
            string licenseNumber = Console.ReadLine();

            currentVehicle = GetUserVehicle(licenseNumber);

            if (currentVehicle == null)
            {
                Console.WriteLine("You didnt create vehicle with such license number, press 0 and create it");
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
                    GarageFunctions();
                }
                else
                {
                    Console.WriteLine("Vehicle already in the garage, updated status to Repairing");
                    GarageFunctions();
                }
            }
        }
        // function #2 
        private void ShowVehicles()
        {
            Console.WriteLine("Insert the status you want to screen by, or press enter");
            
            string input = Console.ReadLine();
            eStatus status;
            List<string> customers;
            if (input.Equals(""))
            {
                customers = garage.LicenseList();
            }
            else
            {
                while(!Enum.TryParse(input , out status))// formatexcecption
                {
                    Console.WriteLine("Wrong status value please choose from the options: " + Enum.GetNames(typeof(eStatus)));
                    input = Console.ReadLine();
                }
                customers = garage.LicenseList(status);    
            }
        }
        //function #3
        private void ChangeStatus()
        {

            Console.WriteLine("Enter license number");
            string licenseNumber = Console.ReadLine();
            GarageCustomer currentCustomer = garage.FindVehicleInGarage(licenseNumber);
            while(currentCustomer == null)
            {
                Console.WriteLine("Couldnt find a vehicle with this license number, enter again");
                licenseNumber = Console.ReadLine();
                currentCustomer = garage.FindVehicleInGarage(licenseNumber);
            }
            Console.WriteLine("Enter status");
            string input = Console.ReadLine();
            eStatus status;
            while(!Enum.TryParse(input, out status))
            {
                Console.WriteLine("You enetered wrong status, please choose from the list: "+ ListEnumOptions(status));
                input = Console.ReadLine();

            }
            garage.ChangeStatus(licenseNumber, status);

        }
            
        // function #4
        private void InflateWheelsToMax()
        {
            Console.WriteLine("Enter license number to inflate wheels");
            string licenseNumber = Console.ReadLine();
            GarageCustomer currentCustomer = garage.FindVehicleInGarage(licenseNumber);
            while (currentCustomer == null)
            {
                Console.WriteLine("Couldnt find a vehicle with this license number, enter again");
                licenseNumber = Console.ReadLine();
                currentCustomer = garage.FindVehicleInGarage(licenseNumber);
            }
            garage.InflateToMax(licenseNumber);
        }

        // function #5 
        public void Refuel()
        {
            Console.WriteLine("Enter license number to refuel");
            string licenseNumber = Console.ReadLine();
            GarageCustomer currentCustomer = garage.FindVehicleInGarage(licenseNumber);
            while (currentCustomer == null)
            {
                Console.WriteLine("Couldnt find a vehicle with this license number, enter again");
                licenseNumber = Console.ReadLine();
                currentCustomer = garage.FindVehicleInGarage(licenseNumber);
            }

            Console.WriteLine("Enter fuel type");
            string input = Console.ReadLine();
            eGasType gasType;
            while (!Enum.TryParse(input, out gasType))// formatexcecption
            {
                Console.WriteLine("You enetered wrong gas type, please choose from the list: " + ListEnumOptions(gasType));
                input = Console.ReadLine();

            }

            Console.WriteLine("Enter amount to fill");
            float amount;
            input = Console.ReadLine();
            while(!float.TryParse(input, out amount))
            {
                Console.WriteLine("Please enter a valid numerical value for the amount ");
                input = Console.ReadLine();
            }

            garage.Refuel(licenseNumber, gasType, amount);
        }


        // function #6
        public void Recharge()
        {
            Console.WriteLine("Enter license number to recharge");
            string licenseNumber = Console.ReadLine();
            GarageCustomer currentCustomer = garage.FindVehicleInGarage(licenseNumber);
            while (currentCustomer == null)
            {
                Console.WriteLine("Couldnt find a vehicle with this license number, enter again");
                licenseNumber = Console.ReadLine();
                currentCustomer = garage.FindVehicleInGarage(licenseNumber);
            }

            Console.WriteLine("Enter number of minutes you want to recharge");
            int numberOfMinutes;
            string input = Console.ReadLine();
            while (!int.TryParse(input, out numberOfMinutes))
            {
                Console.WriteLine("Enter valid integer");
                input = Console.ReadLine();
            }

            garage.Recharge(licenseNumber, (float)numberOfMinutes / 60);

        }

        // function #7 
        public void ShowInfo()
        {
            Console.WriteLine("Enter license number to get vehicle info");
            string licenseNumber = Console.ReadLine();
            
            GarageCustomer currentCustomer = garage.FindVehicleInGarage(licenseNumber);
            while (currentCustomer == null)
            {
                Console.WriteLine("Couldnt find a vehicle with this license number, enter again");
                licenseNumber = Console.ReadLine();
                currentCustomer = garage.FindVehicleInGarage(licenseNumber);
            }
            Vehicle vehicle = currentCustomer.Vehicle;
            
            StringBuilder vehicleInfo = new StringBuilder();
            vehicleInfo.Append("License number: "+ licenseNumber+"\n");
            vehicleInfo.Append("Model name: " + vehicle.Model + "\n");// model name
            vehicleInfo.Append("Owner name: " + currentCustomer.OwnerName + "\n");// owner name
            vehicleInfo.Append("Status: " + currentCustomer.Status + "\n");// status 
            for(int i = 0; i < vehicle.Wheels.Count; i++)
            {
                vehicleInfo.AppendFormat("Wheel #{0} - \n    ", i);
                vehicleInfo.Append("Manufacturer name: " + vehicle.Wheels[i].ManufacturerName);
                vehicleInfo.Append("\n    Current air pressure: " + vehicle.Wheels[i].CurrentAirPressure);
                vehicleInfo.Append("\n    Max air pressure: " + vehicle.Wheels[i].MaxAirPressure);
                vehicleInfo.Append("\n");
            }

            if(currentCustomer.Vehicle.Battery != null){
                vehicleInfo.AppendFormat("Time left: {0} hours \n", vehicle.Battery.TimeLeft);
                vehicleInfo.AppendFormat("Time capacity: {0} hours \n", vehicle.Battery.TimeCapacity);
            }
            else
            {
                vehicleInfo.Append("Gas type: \n" + vehicle.GasTank.GasType);
                vehicleInfo.AppendFormat("Gas amount: {0} liters\n",  vehicle.GasTank.CurrentAmount);
                vehicleInfo.AppendFormat("Gas capacity: {0} liters\n" , vehicle.GasTank.MaxCapacity);
            }

            for (int i = 0; i < vehicle.ExtraTypeData.Count; i++)
            {
                vehicleInfo.Append(vehicle.ExtraTypeData.ElementAt(i).Key + ": " + vehicle.ExtraTypeData.ElementAt(i).Value);
                vehicleInfo.Append("\n");
            }

            Console.WriteLine(vehicleInfo);
        }
    }
    
}