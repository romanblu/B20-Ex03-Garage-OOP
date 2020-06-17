using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;

namespace Ex3.ConsoleUI
{
   public class GarageUI
    {
        private Garage garage = new Garage();
        private CreateNewVehicle factory = new CreateNewVehicle();
        private List<Vehicle> userVehicles = new List<Vehicle>();
        private Validator validator = new Validator();

        public GarageUI(Garage i_Garage)
        {
            this.garage = i_Garage;
        }

        public GarageUI()
        { 
        }

        public void GarageFunctions()
        {
            Console.WriteLine("Welcome, please choose you option from the list below:");
            StringBuilder functionsList = new StringBuilder();
            functionsList.AppendLine("0 - Create you vehicle ");
            functionsList.AppendLine("1 - to enter your car to the garage");
            functionsList.AppendLine("2 - List the vehicles in the garage");
            functionsList.AppendLine("3 - Change vehicle status from the list: " + ListEnumOptions(new eStatus()));
            functionsList.AppendLine("4 - Inflate wheels to max");
            functionsList.AppendLine("5 - Refuel gas vehicle");
            functionsList.AppendLine("6 - Recharge electric vehicle");
            functionsList.AppendLine("7 - To get full info about your vehicle");
            Console.WriteLine(functionsList.ToString());
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
            string inputString = Console.ReadLine();
            float energyLeft = validator.ValidateEnergyLeft(inputString);
            Console.WriteLine("Enter the your vehicle type: {0} ", ListEnumOptions(new eVehicleType()));
            inputString = Console.ReadLine();  
            eVehicleType vehicleType = validator.ValidateEnumType<eVehicleType>(inputString);
            factory.VehicleInProduction(vehicleType, modelName, licenseNumber, energyLeft);
            currentVehicle = validator.ValidateExtraDataForVehicleType(factory, vehicleType);
            List<Wheel> wheels = currentVehicle.Wheels;
            Console.WriteLine("Enter wheels manufacturer or leave at default");
            string wheelsManufacturer = Console.ReadLine();
            for(int i = 0; i < wheels.Count; i++)
            {
                currentVehicle.Wheels[i].ManufacturerName = wheelsManufacturer;
            }

            validator.ValidateWheelsPressure(wheels);
            userVehicles.Add(currentVehicle);
            Console.WriteLine("The vehicle added successfully" );
            GarageFunctions();
        }

        // function #1
        private void AddVehicle()
        {
            Vehicle currentVehicle;
            Console.WriteLine("Enter license number");
            string licenseNumber = Console.ReadLine();
            currentVehicle = GetUserVehicle(licenseNumber);
            if (currentVehicle == null)
            {
                Console.WriteLine("You didnt create vehicle with such license number, press 0 and create it ");
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
                }
            }
            
            GarageFunctions();
        }

        // function #2 
        private void ShowVehicles()
        {
            Console.WriteLine("Insert the status you want to screen by, or press enter");            
            string input = Console.ReadLine();
            List<string> customers;
            if (input.Equals(string.Empty))
            {
                customers = garage.LicenseList();
            }
            else
            {
                eStatus status = validator.ValidateEnumType<eStatus>(input);
                customers = garage.LicenseList(status);    
            }
            
            StringBuilder customersList = new StringBuilder();
            foreach(string licenseNumber in customers)
            {
                customersList.AppendLine(licenseNumber);
            }

            Console.WriteLine(customersList);
            Console.WriteLine("Press anything to get back to main screen");
            Console.ReadLine();
            GarageFunctions();
        }

        // function #3
        private void ChangeStatus()
        {
            Console.WriteLine("Enter license number");
            string licenseNumber = Console.ReadLine();
            GarageCustomer currentCustomer = validator.ValidateVehicleInGarage(licenseNumber, garage);
            Console.WriteLine("Enter status");
            string input = Console.ReadLine();
            eStatus status = validator.ValidateEnumType<eStatus>(input);
            garage.ChangeStatus(licenseNumber, status);
            Console.WriteLine("Status changed succesfully, Press anything to get back to main screen");
            Console.ReadLine();
            GarageFunctions();
        }
            
        // function #4
        private void InflateWheelsToMax()
        {
            Console.WriteLine("Enter license number to inflate wheels");
            string licenseNumber = Console.ReadLine();
            GarageCustomer currentCustomer = validator.ValidateVehicleInGarage(licenseNumber, garage);
            garage.InflateToMax(licenseNumber);
            Console.WriteLine("Wheels inflated succesfully, Press anything to get back to main screen");
            Console.ReadLine();
            GarageFunctions();
        }

        // function #5 
        public void Refuel()
        {
            Console.WriteLine("Enter license number to refuel");
            string licenseNumber = Console.ReadLine();
            GarageCustomer currentCustomer = validator.ValidateVehicleInGarage(licenseNumber, garage);
            if (currentCustomer.Vehicle.GasVehicle)
            {
                Console.WriteLine("Enter fuel type");
                string input = Console.ReadLine();
                eGasType gasType = validator.ValidateEnumType<eGasType>(input);
                Console.WriteLine("Enter amount to fill");
                input = Console.ReadLine();
                validator.ValidateRefuel(gasType, input, licenseNumber, garage);
            }
            else
            {
                Console.WriteLine("Cannot refuel an electric vehicle");
            }

            Console.WriteLine("Press anything to get back to main screen");
            Console.ReadLine();
            GarageFunctions();
        }

        // function #6
        public void Recharge()
        {
            Console.WriteLine("Enter license number to recharge");
            string licenseNumber = Console.ReadLine();
            GarageCustomer currentCustomer = validator.ValidateVehicleInGarage(licenseNumber, garage);
            if (!currentCustomer.Vehicle.GasVehicle)
            {
                Console.WriteLine("Enter number of minutes you want to recharge");
                string input = Console.ReadLine();
                validator.ValidateRecharge(input, licenseNumber, garage); 
            }
            else
            {
                Console.WriteLine("Cannot recharge gas vehicle");
                Console.WriteLine("Press anything to get back to main screen");
                Console.ReadLine();
                GarageFunctions();
            }
        }

        // function #7 
        public void ShowInfo()
        {
            Console.WriteLine("Enter license number to get vehicle info");
            string licenseNumber = Console.ReadLine();
            GarageCustomer currentCustomer = validator.ValidateVehicleInGarage(licenseNumber, garage);
            Vehicle vehicle = currentCustomer.Vehicle;
            StringBuilder vehicleInfo = new StringBuilder();
            vehicleInfo.AppendLine(string.Format(@"License number: {0}", licenseNumber ));
            vehicleInfo.AppendLine(string.Format(@"Model name: {0}", vehicle.Model )); // model name
            vehicleInfo.AppendLine(string.Format("Owner name: {0}", currentCustomer.OwnerName )); // owner name
            vehicleInfo.AppendLine(string.Format(@"Status: {0}", currentCustomer.Status )); // status
            vehicleInfo.AppendLine();
            for(int i = 0; i < vehicle.Wheels.Count; i++)
            {
                vehicleInfo.AppendLine(string.Format(@"Wheel #{0} -", i)); // chack change
                vehicleInfo.AppendLine(string.Format(@"    Manufacturer name: {0}", vehicle.Wheels[i].ManufacturerName));
                vehicleInfo.AppendLine(string.Format(@"    Current air pressure: {0}", vehicle.Wheels[i].CurrentAirPressure));
                vehicleInfo.AppendLine(string.Format(@"    Max air pressure: {0}", vehicle.Wheels[i].MaxAirPressure));   
            }

            vehicleInfo.AppendLine();

            if (currentCustomer.Vehicle.Battery != null)
            {
                vehicleInfo.AppendLine(string.Format(@"Time left: {0} hours ", vehicle.Battery.TimeLeft));
                vehicleInfo.AppendLine(string.Format(@"Time capacity: {0} hours ", vehicle.Battery.TimeCapacity));
            }
            else
            {
                vehicleInfo.AppendLine(string.Format("Gas type: {0} ", vehicle.GasTank.GasType));
                vehicleInfo.AppendLine(string.Format(@"Gas amount: {0} liters ",  vehicle.GasTank.CurrentAmount));
                vehicleInfo.AppendLine(string.Format(@"Gas capacity: {0} liters ", vehicle.GasTank.MaxCapacity));
            }

            for (int i = 0; i < vehicle.ExtraTypeData.Count; i++)
            {
                vehicleInfo.AppendLine(string.Format(@"{0} : {1}", vehicle.ExtraTypeData.ElementAt(i).Key, vehicle.ExtraTypeData.ElementAt(i).Value));
            }

            vehicleInfo.AppendLine();
            Console.WriteLine(vehicleInfo);

            Console.WriteLine("Press anything to get back to main screen");
            Console.ReadLine();
            GarageFunctions();
        }
    }   
}